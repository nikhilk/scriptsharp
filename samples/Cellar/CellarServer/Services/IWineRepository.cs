// IWineRepository.cs
//

using System;
using System.Threading;
using Cellar.DataModels;

namespace Cellar.Services {

    public interface IWineRepository {

        Task<int> CountWines();

        Task InsertWines(Wine[] wines);

        Task<Wine> LookupWine(int id);

        Task<Wine[]> QueryWines(int skip, int count);
    }
}
