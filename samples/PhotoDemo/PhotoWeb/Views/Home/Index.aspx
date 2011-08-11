<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Gallery</title>
  <style type="text/css">
    body { background-color: black; text-align: center; }
    h1 { font-family: Calibri; font-size: 32pt; font-weight: normal; color: white; margin-bottom: 20px; }
    input, button, label { font-family: Georgia; font-size: 16pt; }
    #inputPanel, #thumbsList { margin-bottom: 10px; }
    #photoPanel { background-color: white; padding: 4px; display: inline-block; }
    #thumbsList { font-size: 0pt; }
    #thumbsList li { display: inline-block; margin: 10px; padding: 4px; border: double 1px #404040;  cursor: hand; }
    #thumbsList img.thumbnail { width: 75px; height: 75px; }
    #thumbsList img.preload { width: 0px; height: 0px; }
  </style>
</head>
<body>
  <h1>Interestingness Gallery</h1>
  <div id="inputPanel">
    <label>Enter some tags:</label><br />
    <input type="text" id="tagsTextBox" size="40" />
    <button type="button" id="searchButton">Browse</button>
  </div>
  <div id="gallery">
    <ul id="thumbsList"></ul>
    <div id="photoPanel" style="display: none"></div>
  </div>
  <script type="text/html" id="thumbnailTemplate">
    <li>
      <img class="thumbnail" src="${url_sq}" title="${title}" />
      <img class="preload" src="${url_m}" />
    </li>
  </script>
  <script type="text/html" id="photoTemplate">
    <img src="${url_m}" title="${title}" />
    <br />
    <label>${title}</label>
  </script>

  <script type="text/javascript" src="http://code.jquery.com/jquery-1.4.2.js"></script>
  <script type="text/javascript" src="/Content/Scripts/jquery.tmpl.js"></script>
  <script type="text/javascript" src="/Content/Scripts/jquery.bbq.js"></script>
  <script type="text/javascript" src="/Content/Scripts/mscorlib.js"></script>
  <script type="text/javascript" src="/Content/Scripts/Flickr.debug.js"></script>
  <script type="text/javascript" src="/Content/Scripts/Gallery.debug.js"></script>
  <script type="text/javascript">
    Gallery.Interestingness.main();
  </script>
</body>
</html>
