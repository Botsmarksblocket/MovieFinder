window.scrollHelper = {
    registerScroll: function (dotNetHelper) {
        window.addEventListener("scroll", () => {
            const scrollY = window.scrollY || window.pageYOffset;
            const viewportHeight = window.innerHeight;
            const fullHeight = document.body.scrollHeight;

            if (scrollY + viewportHeight >= fullHeight - 300) {
                dotNetHelper.invokeMethodAsync("OnScrollNearBottom");
            }
        });
    }
};