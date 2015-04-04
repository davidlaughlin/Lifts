var FitnessTestListViewModel = function () {
    var self = this;

    this.skillProgress = ko.pureComputed(function () {
        if (self.allItems == null) {
            return 0;
        }

        var completedCount = 0;
        for (var i = 0; i < self.allItems().length; i++) {
            if (self.allItems()[i].completed()) {
                completedCount++;
            }
        }

        var percentCompleted = (completedCount / self.allItems().length) * 100;
        return percentCompleted;
    });

    self.allItems = ko.observableArray([]);
    self.selectedItem = ko.observable("");


    var url = "/Skills/Detail?name=Flexibility";
    $.ajax(url, {
        type: "GET",
        cache: false
    }).done(function (data) {
        //ko.mapping.fromJS(data, {}, self);
        for (var i = 0; i < data.length; i++) {
            var fitnessTest = {
                name: data[i].name,
                completed: ko.observable(data[i].completed)
            };

            self.allItems.push(fitnessTest);
        }
    }).fail(function (jqXHR, status) {
        console("Request failed: " + status);
    });

}

ko.applyBindings(new FitnessTestListViewModel());