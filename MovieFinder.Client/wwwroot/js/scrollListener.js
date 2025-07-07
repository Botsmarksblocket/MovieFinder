window.scrollHelper = {
    _scrollHandler: null,

    registerScroll: function (dotNetHelper) {

        if (this._scrollHandler) return;

        this._scrollHandler = () => {
            const scrollY = window.scrollY || window.pageYOffset; //Current scroll position
            const viewportHeight = window.innerHeight;            //Height of visible window
            const fullHeight = document.body.scrollHeight;        //Total page height

            // If user is withing 300 px of bottom, notify blazor
            if (scrollY + viewportHeight >= fullHeight - 300) {
                dotNetHelper.invokeMethodAsync("OnScrollNearBottom");
            }
        };
        window.addEventListener("scroll", this._scrollHandler);
    },

    removeScroll: function () {
        if (this._scrollHandler) {
            window.removeEventListener("scroll", this._scrollHandler);
            this._scrollHandler = null;
        }
    }
};

