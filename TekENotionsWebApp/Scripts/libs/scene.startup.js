var startup = function () {

    var windowFocused = true,
        init = function () {
            $(window).focus(function () {
                windowFocused = true;
            });

            $(window).blur(function () {
                windowFocused = false;
            });

            var defaultPositions = sceneLayoutService.get();

            $('#gridButton').click(function () {
                sceneStateManager.changeScene();
            });

            $('#cloudbutton').click(function () {
                sceneStateManager.changeScene();
            });
            sceneStateManager.init(defaultPositions);
            sceneStateManager.renderTiles();

            setTimeout(function () {
                dataService.getTickerQuotes(renderTicker);
                $('#logo').delay('500').fadeIn('slow');

                $('.tile').each(function () {$(this.fadeIn(360))

                });

            });

            setInterval(function () {

            });

        }


}();