<%@ Page Language="C#" Inherits="System.Web.Mvc.DynamicViewPage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Photos Around Me</title>
  <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Schoolbell:regular" />
  <link rel="stylesheet" type="text/css" href="/Content/Site.css" />
</head>
<body class="map"
  data-flickr-key="<%= Model.flickrApiKey %>"
  data-bingmaps-key="<%= Model.bingMapsKey %>"
  data-tile-url="<%= Model.tileUrl %>">
  <div id="mapContainer"></div>
  <div id="inputContainer">
    <div id="titleLabel">Photos Around Me</div>
    <form id="searchForm" action="" onsubmit="return false;">
      <input type="text" id="searchBox" placeholder="search keywords" />
      <button type="submit" id="searchButton" title="Search">Search</button>
      <button type="button" id="favButton" title="Show Favorites">Favorites</button>
      <button type="button" id="locateMeButton" title="Locate Me">Locate Me</button>
      <div id="searchProgress"></div>
    </form>
  </div>
  <div id="photoOverlay">
    <div id="photoContainer">
      <span id="photo"></span>
      <button id="photoCloseButton" type="button" class="photoAction">close</button>
      <br />
      <span id="photoTitle"></span>
      <button id="photoSourceButton" type="button" class="photoAction" title="Flickr Page">flickr</button>
      <button id="photoSaveButton" type="button" class="photoAction" title="Save to Favorites">save</button>
      <button id="photoShareButton" type="button" class="photoAction" title="Share on Twitter">share</button>
      <button id="photoAroundButton" type="button" class="photoAction" title="More Around this Photo">around</button>
      <div id="photoTweet"></div>
    </div>
  </div>
  <script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0"></script>
  <script type="text/javascript" src="http://platform.twitter.com/anywhere.js?id=BDvnYA8jh6osbRb83Ybw&v=1"></script>
  <script type="text/javascript" src="/Content/Scripts/mscorlib.debug.js"></script>
  <script type="text/javascript" src="/Content/Scripts/AroundMe.debug.js"></script>
</body>
</html>
