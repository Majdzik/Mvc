var f = window.location.hash;
((f !== undefined || f !== 'undefined' || f !== '' || f !== null) && (document.getElementById(f.substr(1)) !== null)) ? { id: f.substr(1), el: document.getElementById(f.substr(1)) } : (null)

var dzik = {
    
    d: document,
    h: window.location.hash,
    Hash: (((h !== undefined || h !== 'undefined' || h !== null) && (h !== '') && (GI(h.substr(1)) !== null)) ? { id: h.substr(1), el: GI(h.substr(1)) } : (null)),
    GI: function (str) { return d.getElementById(str); },
    GC: function (str) { return d.getElementsByClassName(str); },
    GN: function (str) { return d.getElementsByName(str); },
    GT: function (str) { return d.getElementsByTagName(str); },
    GS: function(str) { return d.getElementsByTagNameNS(str); }

};
dzik.GI()

var zik =  function () {
    var p = Object.getPrototypeOf(this);
    p.method = function() {};
    p.d = document;
    p.h = window.location.hash;
};


