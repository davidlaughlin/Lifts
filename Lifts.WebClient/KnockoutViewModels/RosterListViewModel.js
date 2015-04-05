var RosterListViewModel = {
    // Properties
    allRosters: ko.observableArray([]),

    // Functions
    getAllRosters: function () {
        var self = this;
        var url = "/Roster/Index/";
        $.ajax(url, {
            type: "GET",
            cache: false,
            async: false
        }).done(function(data) {
            //ko.mapping.fromJS(data, {}, self);
            for (var i = 0; i < data.length; i++) {
                var roster = {
                    id: data[i].id,
                    name: data[i].name,
                    enrollment: data[i].enrollment,
                    rosterLink: "/Roster/Detail?rosterId=" + data[i].id
                };

                self.allRosters.push(roster);
            }
        }).fail(function(jqXHR, status) {
            console("Request failed: " + status);
        });
    }
}