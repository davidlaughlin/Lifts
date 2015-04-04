function SkillViewModel(name, description, progress) {
    var self = this;

    self.name = ko.observable(name);
    self.progress = ko.observable(progress);

    //self.skills =
    //[
    //    { name: 'Cardiovascular', progress: 14 },
    //    { name: 'Stamina', progress: 35 },
    //    { name: 'Strength', progress: 45 },
    //    { name: 'Flexibility', progress: 29 },
    //    { name: 'Power', progress: 65 },
    //    { name: 'Speed', progress: 9 },
    //    { name: 'Coordination', progress: 3 },
    //    { name: 'Agility', progress: 100 },
    //    { name: 'Balance', progress: 82 },
    //    { name: 'Accuracy', progress: 99 }
    //];
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