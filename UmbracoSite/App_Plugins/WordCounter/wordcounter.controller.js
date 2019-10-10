angular.module("umbraco")
    .controller("My.WordCounterApp", function ($scope, editorState, userService, contentResource) {

        var vm = this;
        vm.CurrentNodeId = editorState.current.id;
        vm.CurrentNodeAlias = editorState.current.contentTypeAlias;

        if (vm.CurrentNodeId == 0 || vm.CurrentNodeAlias == "Image") {
            return;
        }
        var counter = contentResource.getById(vm.CurrentNodeId).then(function (node) {
            var properties = node.variants[0].tabs[0].properties;

            vm.propertyWordCount = {};

            var index;
            for (index = 0; index < properties.length; ++index) {
                var words = properties[index].value;
                var wordCount = words.trim().split(/\s+/).length;

                vm.propertyWordCount[properties[index].label] = wordCount;
            }
        });

        var user = userService.getCurrentUser().then(function (user) {
            vm.UserName = user.name;
        });
    });