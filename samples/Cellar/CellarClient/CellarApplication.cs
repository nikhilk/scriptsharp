// CellarApplication.cs
//

using System;
using System.Collections.Generic;
using System.Net;
using System.Serialization;
using Cellar.DataModels;
using KnockoutApi;

namespace Cellar {

    public sealed class CellarApplication {

        private const int WinesPerPage = 8;

        private readonly Observable<int> _pageIndex;
        private readonly Observable<int> _pages;

        public readonly ComputedObservable<bool> CanGoPrevious;
        public readonly ComputedObservable<bool> CanGoNext;
        public readonly Observable<IEnumerable<Wine>> Wines;
        public readonly Observable<Wine> SelectedWine;
        public readonly ComputedObservable<bool> ShowSelection;

        public readonly Action Next;
        public readonly Action Previous;
        public readonly Action<Wine> Select;

        public CellarApplication() {
            _pages = Knockout.Observable<int>(0);
            _pageIndex = Knockout.Observable<int>(0);

            Wines = Knockout.Observable<IEnumerable<Wine>>();
            SelectedWine = Knockout.Observable<Wine>();
            CanGoPrevious = Knockout.Computed<bool>(ComputeCanGoPrevious);
            CanGoNext = Knockout.Computed<bool>(ComputeCanGoNext);
            ShowSelection = Knockout.Computed<bool>(ComputeShowSelection);

            Next = delegate() {
                NextCommand();
            };
            Previous = delegate() {
                PreviousCommand();
            };
            Select = delegate(Wine wine) {
                SelectCommand(wine);
            };

            LoadWines();
        }

        private bool ComputeCanGoNext() {
            return _pageIndex.GetValue() < (_pages.GetValue() - 1);
        }

        private bool ComputeCanGoPrevious() {
            return _pageIndex.GetValue() > 0;
        }

        private bool ComputeShowSelection() {
            return SelectedWine.GetValue() != null;
        }

        private void LoadWines() {
            int skip = _pageIndex.GetValue() * WinesPerPage;

            XmlHttpRequest xhr = new XmlHttpRequest();
            xhr.OnReadyStateChange = delegate() {
                if ((xhr.ReadyState == ReadyState.Loaded) &&
                    (xhr.Status == 200)) {
                    WineResults results = Json.ParseData<WineResults>(xhr.ResponseText);

                    if (results.Count != 0) {
                        _pages.SetValue(Math.Ceil(results.Count / WinesPerPage));
                    }

                    Wines.SetValue(results.Wines);

                    Wine selectedWine = null;
                    if ((results.Wines != null) && (results.Wines.Length != 0)) {
                        selectedWine = results.Wines[0];
                    }
                    SelectedWine.SetValue(selectedWine);
                }
            };

            xhr.Open(HttpVerb.Get, "/wines/?skip=" + skip + "&count=" + WinesPerPage, true);
            xhr.Send();
        }

        private void PreviousCommand() {
            _pageIndex.SetValue(_pageIndex.GetValue() - 1);
            LoadWines();
        }

        private void NextCommand() {
            _pageIndex.SetValue(_pageIndex.GetValue() + 1);
            LoadWines();
        }

        private void SelectCommand(Wine wine) {
            SelectedWine.SetValue(wine);
        }
    }
}
