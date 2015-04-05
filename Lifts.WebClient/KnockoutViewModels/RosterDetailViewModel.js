var RosterDetailViewModel = {

    // Properties
    allAthletes: ko.observableArray([]),
    selectedItem: ko.observable(),

    //Functions
    getAllAthletes: function () {
        var self = this;
        var url = "/Roster/Detail?rosterId=" + queries["rosterId"];
        $.ajax(url, {
            type: "GET",
            cache: false
        }).done(function(data) {
            //ko.mapping.fromJS(data, {}, self);
            for (var i = 0; i < data.length; i++) {
                var athlete = {
                    id: data[i].id,
                    firstName: data[i].firstName,
                    lastName: data[i].lastName,
                    athleteLink: "/Skills/Index?athleteId=" + data[i].id
                };

                self.allAthletes.push(athlete);
            }
        }).fail(function(jqXHR, status) {
            console("Request failed: " + status);
        });
    }
}

var queries = {};
$.each(document.location.search.substr(1).split('&'), function (c, q) {
    var i = q.split('=');
    queries[i[0].toString()] = i[1].toString();
});


$(function () {
    ko.applyBindings(RosterDetailViewModel);
    RosterDetailViewModel.getAllAthletes();
})