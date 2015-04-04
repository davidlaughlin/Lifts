function SkillViewModel(name, description, progress) {
    var self = this;

    self.name = ko.observable(name);
    self.progress = ko.observable(progress);
}

function SkillListViewModel() {
    var self = this;

    self.allItems = ko.observableArray([]);
    self.selectedItem = ko.observable("");

    var url = "/Skills/Index";
    $.ajax(url, {
        type: "GET",
        cache: false
    }).done(function (data) {
        //ko.mapping.fromJS(data, {}, self);
        for (var i = 0; i < data.length; i++) {
            self.allItems.push(data[i]);
        }
    }).fail(function (jqXHR, status) {
        console("Request failed: " + status);
    });
}

ko.applyBindings(new SkillListViewModel());