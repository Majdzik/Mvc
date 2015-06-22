/*  Copyright 2007  Scibuff - Tomas Vorobjov  (email : blog@scibuff.com)

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

if (!com) { var com = {}; }
if (!com.scibuff) { com.scibuff = {}; }
if (!com.scibuff.dev) { com.scibuff.dev = {}; }
if (!com.scibuff.dev.ajax) {
    com.scibuff.dev.ajax = function () {
        // private fields
        var tmp = {};
        tmp.URL_CHECK_INTERVAL = 100;
        tmp.HASH_VARS_SEPARATOR = ';';
        tmp.internalUrlChange = false;
        tmp.oldURL = window.location.href;

        /**
         * Checks if the window url has changed and if so,
         * triggers a "change" events
         */
        tmp.checkURL = function () {
            if (tmp.oldURL != window.location.href) {
                tmp.oldURL = window.location.href;
                $(window.location).trigger(
                    pub.URL_CHANGED, { url: window.location.href }
                );
            }
        }

        /**
         * This function is executed every time the browser's url
         * is changed 
         * @param {Object} event
         * @param {Object} data
         */
        tmp.urlChangeHandler = function (event, data) {
            if (!tmp.internalUrlChange) {
                var data = tmp.getHashVars();
                if (data[pub.PAGE_VAR_NAME] != "") {
                    tmp.loadPageContent(data[pub.PAGE_VAR_NAME], "#content");
                }

            }
            tmp.internalUrlChange = false;
        }

        /**
         * Parses the url hash string into a vars (JSON) object
         */
        tmp.getHashVars = function () {
            var url = window.location.href;
            if (url.match('#')) {
                var hash = url.split('#')[1];
                var hashes = hash.split(tmp.HASH_VARS_SEPARATOR);
                var data = {};
                for (var i in hashes) {
                    if (hashes[i] != "") {
                        var tuple = hashes[i].split("=");
                        data[tuple[0]] = unescape(tuple[1]);
                    }
                }
                return data;
            }
            return {};
        }

        /**
         * Sets the url hash string using the values from the vars object
         * @param {Object} vars
         */
        tmp.setHashVars = function (vars) {

            var url = window.location.href;

            if (url.match('#')) { url = url.split('#')[0]; }

            var hash = "";
            for (var key in vars) {
                if (vars[key]) {
                    hash += key + "=" + escape(vars[key]) + tmp.HASH_VARS_SEPARATOR;
                }
            }

            tmp.internalUrlChange = true;
            window.location = url + "#" + hash;
        }

        /**
         * Sets ajax link to th
         * @param {Object} element
         * @param {Object} clickEvent
         */
        tmp.setAjaxLink = function (element, clickEvent) {
            clickEvent.preventDefault();
            var url = element.attr("href");
            tmp.loadPageContent(url, "#content");
        };

        /**
         * Loads content from the specified url
         * @param {String} url
         * @param {String} destination
         */
        tmp.loadPageContent = function (url, destination) {
            var data = tmp.getHashVars();
            data[pub.PAGE_VAR_NAME] = url;
            tmp.setHashVars(data);
            $(destination).load(url, { 'ajax': 'true' }, function () {
                $(destination + ' a.ajax-link').click(function (event) {
                    tmp.setAjaxLink($(this), event);
                });
            });
        }

        // public fields
        var pub = {};
        pub.PAGE_VAR_NAME = "page";
        pub.URL_CHANGED = "change";
        pub.init = function () {
            var data = tmp.getHashVars();
            if (data[pub.PAGE_VAR_NAME] != "") {
                tmp.loadPageContent(data[pub.PAGE_VAR_NAME], "#content");
            }

            $(window.location).bind(pub.URL_CHANGED, tmp.urlChangeHandler);

            setInterval(tmp.checkURL, tmp.URL_CHECK_INTERVAL);
            $('a.ajax-link').click(function (event) {
                tmp.setAjaxLink($(this), event);
            });
        }

        return pub;
    }();
}

$(document).ready(function () {

    com.scibuff.dev.ajax.init();

});