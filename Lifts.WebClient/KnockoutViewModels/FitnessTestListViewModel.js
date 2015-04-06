var FitnessTestListViewModel = {

    

    // Functions
    getAllFitnessTests: function () {
        var self = this;
        var url = "/Skills/Detail?athleteId=" + queries["athleteId"] + "&name=" + queries["name"];
        $.ajax(url, {
            type: "GET",
            cache: false
        }).done(function (data) {
            //ko.mapping.fromJS(data, {}, self);
            for (var i = 0; i < data.length; i++) {
                var fitnessTest = {
                    id: data[i].id,
                    name: data[i].name,
                    completed: ko.observable(data[i].completed)
                };

                self.allFitnessTests.push(fitnessTest);
            }

        }).fail(function (jqXHR, status) {
            console("Request failed: " + status);
        });
    },

    saveFitnessTest: function (index, data, event) {
        var self = this;
        var idx = index();

        var fitnessTest = {
            id: self.allFitnessTests()[idx].id,
            name: self.allFitnessTests()[idx].name,
            completed: self.allFitnessTests()[idx].completed()
        };

        $.ajax({
            url: "/Skills/Save?athleteId=" + queries["athleteId"],
            type: "POST",
            data: JSON.stringify(fitnessTest),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
            },
            error: function (status) {
                alert('error: ' + status);
            }
        });

        return true;
    },

    // Event Handlers
    onCheckBoxClick: function (index, data, event) {
        var self = this;

        
        return self.saveFitnessTest(index, data, event);
    }
}

FitnessTestListViewModel.skillProgress = ko.computed(function () {
    var self = this;
    if (self.allFitnessTests == null) {
        return 0;
    }

    var completedCount = 0;
    for (var i = 0; i < self.allFitnessTests().length; i++) {
        if (self.allFitnessTests()[i].completed()) {
            completedCount++;
        }
    }

    var percentCompleted = (completedCount / self.allFitnessTests().length) * 100;
    return Math.floor(percentCompleted);
}, FitnessTestListViewModel);

var queries = {};
$.each(document.location.search.substr(1).split('&'), function (c, q) {
    var i = q.split('=');
    queries[i[0].toString()] = i[1].toString();
});

$(function () {
    ko.applyBindings(FitnessTestListViewModel);
    FitnessTestListViewModel.getAllFitnessTests();
})