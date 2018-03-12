﻿var sceneStateManager = function () {
    var sceneId = 1,
        animateSpeed = 760,
        tiles,
        init = function (args) {
            tiles = args.tiles;

            $(tiles).each(function (index) {
                //build tiles
                var tileDiv = $('<div/>', { 'class': 'tile', 'text': this.name, 'id': this.tileId });
                tileDiv.css('border-top', '5px solid ' + this.scenes[sceneId].borderColor);
                tileDiv.data(this);

                moveTile(tileDiv, this.scenes[sceneId]);
                tileDiv.appendTo('#content');

                if (index < 8) {
                    tileDiv.addClass('top-row');
                }

                tileDiv.draggable({ opacity: 0.9, zIndex: 5000, revert: 'invalid', revertDuration: 500 });
                tileDiv.droppable({
                    tolerance: 'pointer',
                    drop: function (event, ui) {
                        swapTiles(ui.draggable, $(this));
                    }
                });
            });

            $('#left').click(slideRight);
            $('#right').click(slideLeft);
        },

        renderTiles = function (acctNumber) {
            //Call data service delegate to get account information
            //Once information returns bindTiles will be invoked
            dataService.getAccount(acctNumber, renderAccountTiles);
            dataService.getMarketIndexes(renderMarketTiles);
            renderDefaultTiles();
        },

        renderAccountTiles = function (data) {
            $('div.tile[id^="Account"]').each(function () {
                var tileDiv = $(this);
                renderTile(data, tileDiv, 0);
            });
        },

        renderMarketTiles = function (data) {
            renderTile(data, $('#DOW'), 0);
            renderTile(data, $('#NASDAQ'), 0);
            renderTile(data, $('#SP500'), 0);
        },

        renderTile = function (data, tile, fadeInAmount) {
            if (fadeInAmount > 0) tile.fadeOut(fadeInAmount);
            if (fadeInAmount > 0) {
                tile.fadeIn(fadeInAmount,
                    function () {
                        tileBinder.bind(tile, data, tileRenderer.render);
                    }
                );
            }
            else {
                tileBinder.bind(tile, data, tileRenderer.render);
            }
        },

        renderDefaultTiles = function () {
            $('#Video, #Quote, #SectorSummary, #MarketNews, #Currencies').each(function () {
                if ($(this).data().templates == null) {
                    var tileDiv = $(this);
                    tileBinder.bind(tileDiv, null, tileRenderer.render);
                }
            });
        },

        swapTiles = function (source, target) {
            var sourceScene = source.data().scenes[sceneId];
            var targetScene = target.data().scenes[sceneId];

            moveTile(target, sourceScene);
            moveTile(source, targetScene);

            swapScenes(sourceScene, targetScene);

            if (sceneId == 0) {
                //handle top row scrolling
                var sourceTopRow = source.hasClass('top-row');
                var targetTopRow = target.hasClass('top-row');
                if (sourceTopRow && !targetTopRow) {
                    source.removeClass('top-row');
                    target.addClass('top-row');
                } else if (!sourceTopRow && targetTopRow) {
                    target.removeClass('top-row');
                    source.addClass('top-row');
                }
            }

            //resize
            var sourceSize = sourceScene.size;
            var targetSize = targetScene.size;
            if (sourceSize != targetSize) {

                target.data().scenes[sceneId].size = sourceSize;
                source.data().scenes[sceneId].size = targetSize;

                tileRenderer.render(target);
                tileRenderer.render(source);
            }
        },

        slideLeft = function () {
            $('.top-row').animate({ 'left': '-=250px' }, 800, function () {
                $(this).data().scenes[sceneId].left -= 250;
            });
        },

        slideRight = function () {
            $('.top-row').animate({ 'left': '+=250px' }, 800, function () {
                $(this).data().scenes[sceneId].left += 250;
            });
        },

        changeScene = function () {
            if (sceneId == 0) {
                sceneId = 1;
                $('.scroller').hide();
                $('#gridButton').delay(Math.floor(Math.random() * 450)).attr('disabled', false).addClass('enabled');
                $('#cloudButton').delay(Math.floor(Math.random() * 450)).attr('disabled', true).removeClass('enabled');

            } else if (sceneId == 1) {
                sceneId = 0;
                $('.scroller').show();
                $('#cloudButton').attr('disabled', false).addClass('enabled');
                $('#gridButton').attr('disabled', true).removeClass('enabled');
            }

            $('.tile').each(function () {
                var tile = $(this);
                moveTile(tile, tile.data().scenes[sceneId]);
                tileRenderer.render(tile, sceneId);
            });
        },

        moveTile = function (tile, scene) {
            tile.animate({
                opacity: scene.opacity,
                top: scene.top,
                left: scene.left,
                height: scene.height,
                width: scene.width,
                zIndex: scene.z
            },
                {
                    duration: animateSpeed,
                    easing: "easeInOutExpo",
                    step: function () { },
                    complete: function () { }
                });
        },

        swapScenes = function (source, target) {
            var top = source.top,
                left = source.left,
                height = source.height,
                width = source.width,
                opacity = source.opacity,
                zindex = source.zindex;

            source.top = target.top;
            source.left = target.left;
            source.height = target.height;
            source.width = target.width;
            source.opacity = target.opacity;
            source.zindex = target.zindex;

            target.top = top;
            target.left = left;
            target.height = height;
            target.width = width;
            target.opacity = opacity;
            target.zindex = zindex;
        };

    return {
        init: init,
        changeScene: changeScene,
        getTiles: function () { return tiles; },
        renderTiles: renderTiles,
        renderAccountTiles: renderAccountTiles,
        renderMarketTiles: renderMarketTiles,
        renderTile: renderTile
    };

}();

//    var zoomTile = function(tile) {
//        var zoomed = tile.attr('zoom');

//        if (zoomed == 0) {
//            tile.css('z-index', 10000);
//            tile.attr('zoom', 1);
//            moveTile(tile, { opacity: 1, top: 0, left: -2, height: 590, width: 1200 });
//        } else {

//            var scene = tile.data().scenes[sceneId];
//            reset();
//            scene.opacity = 1;

//            moveTile(tile, scene);

//            tile.css('z-index', 1000);
//            tile.attr('zoom', 0);
//        }

//        tileRenderer.render(tile, sceneId);
//    };

//    var reset = function() {
//        $('.tile').each(function(index) {
//            if (sceneId == 1) {
//                $(this).data().scenes[sceneId].opacity = .5;
//                $(this).css('opacity', .5);
//                $(this).css('z-index', 1000);
//            }
//        });
//    };

