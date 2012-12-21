(function() {
  var startTagRegex = /^<([^>\s\/]+)((\s+[^=>\s]+(\s*=\s*((\"[^"]*\")|(\'[^']*\')|[^>\s]+))?)*\s*\/?\s*)>/m,
      endTagRegex = /^<\/([^>\s]+)[^>]*>/m,
      attrsRegex = /([^=\s]+)(\s*=\s*((\"([^"]*)\")|(\'([^']*)\')|[^>\s]+))?/gm;

  function sharpenTemplate(content) {
    var _code = [];
    var _buffer = [];
    var _stack = [];

    function writeCode(s) {
      if (_buffer.length) {
        var text = _buffer.join('');
        text.length && _code.push('_text("' + _buffer.join('').replace(/"/g, '\\"') + '");');
        _buffer = [];
      }
      _code.push(s);
    }

    function writeText(s) {
      _buffer.push(s);
    }

    function writeValue(value) {
      if (value && value.length) {
        for (var i = 0; i < value.length; ) {
          var beginIndex = value.indexOf("{{", i);
          if (beginIndex < 0) {
            break;
          }
          var endIndex = value.indexOf("}}", beginIndex + 2);
          if (endIndex < 0) {
            break;
          }
          writeText(value.substring(i, beginIndex));

          var expr = value.substring(beginIndex + 2, endIndex).trim();
          writeCode('_text(' + ((expr != '.') ? expr : 'i') + ');');
          i = endIndex + 2;
        }
        writeText(value.substr(i).trim());
      }
    }

    function handleStartElement(tag, attrs, closed) {
      var frame = {};
      _stack.push(frame);

      if (attrs.loop) {
        frame.loop = attrs.loop;
        delete attrs.loop;
      }
      else if (attrs['if']) {
        writeCode('if (' + attrs['if'] + ') {');
        frame.conditional = true;
        delete attrs['if'];
      }
      else if (attrs['elseif']) {
        writeCode('else if (' + attrs['elseif'] + ') {');
        frame.conditional = true;
        delete attrs['elseif'];
      }
      else if (typeof attrs['else'] !== 'undefined') {
        writeCode('else {');
        frame.conditional = true;
        delete attrs['else'];
      }

      writeText('<' + tag);
      for (var attr in attrs) {
        var value = attrs[attr];

        if (!value) {
          writeText(' ' + attr);
        }
        else if (value.startsWith('?{{') && value.endsWith('}}')) {
          value = value.substr(3, value.length - 5);
          writeCode('if (_t = (' + value + ')) {');
          writeText(' ' + attr + '="');
          writeCode('_text(_t);');
          writeText('"');
          writeCode('}');
        }
        else {
          writeText(' ' + attr + '="');
          writeValue(value);
          writeText('"');
        }
      }
      if (closed) {
        writeText(' />', true);
        handleEndElement(tag, closed);
      }
      else {
        writeText('>');
        frame.loop && writeCode('_loop(' + frame.loop + ', function(i) { with(i) {');
      }
    }
    function handleEndElement(tag, closed) {
      var frame = _stack.pop();

      frame.loop && writeCode('}});');
      !closed && writeText('</' + tag + '>');
      frame.conditional && writeCode('}');
    }
    function handleText(s) {
      writeValue(s);
    }

    function parseContent(content) {
      var treatAsText = true;
      while (content.length) {
        if (content.substring(0, 4) == '<!--') {
          var index = content.indexOf('-->');
          if (index != -1) {
            content = content.substring(index + 3);
            treatAsText = false;
          }
        }
        else if (content.substring(0, 2) == '</') {
          if (endTagRegex.test(content)) {
            content = RegExp.rightContext;

            RegExp.lastMatch.replace(endTagRegex, function(tag, tagName) {
              handleEndElement(tagName)
            });

            treatAsText = false;
          }
        }
        else if (content.charAt(0) == '<') {
          if (startTagRegex.test(content)) {
            content = RegExp.rightContext;

            RegExp.lastMatch.replace(startTagRegex, function(tag, tagName, rest) {
              var closed = false;
              var attrs = {};
              rest.replace(attrsRegex, function(match, name, p1, p2, p3, p4, p5, p6, offset, all) {
                if (name == '/') {
                  closed = true;
                  return;
                }
                attrs[name] = p5 ? p6 : (p3 ? p4 : (p1 ? p2 : null));
              });

              handleStartElement(tagName, attrs, closed);
            });

            treatAsText = false;
          }
        }

        if (treatAsText) {
          var index = content.indexOf("<");
          if (index == -1) {
            handleText(content);
            break;
          }
          else {
            handleText(content.substring(0, index));
            content = content.substring(index);
          }
        }

        treatAsText = true;
      }
    }

    writeCode('var _ = [], _t;');
    writeCode('function _text(t) { _.push(t); }');
    writeCode('function _loop(a,f) { a && a.forEach(f); }');
    writeCode('with (_d) {');

    parseContent(content.replace(/[\r\n\t]/g, ' '));

    writeCode('}');
    writeCode('return _.join("");');

    return new Function('_d', 'index', 'ctx', _code.join('\n'));
  }

  Sharpen$Html$Application.current.registerTemplateEngine('sharpen', sharpenTemplate);
})();