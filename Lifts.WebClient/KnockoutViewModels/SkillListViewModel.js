var SkillListViewModel = {

    // Properties
    allSkills: ko.observableArray([]),

    // Functions
    getAllSkills: function () {
        var self = this;

        var url = "/Skills/Index?athleteId=" + queries["athleteId"];
        $.ajax(url, {
            type: "GET",
            cache: false
        }).done(function (data) {
            //ko.mapping.fromJS(data, {}, self);
            for (var i = 0; i < data.length; i++) {
                var skill = {
                    id: data[i].id,
                    name: data[i].name,
                    progress: data[i].progress,
                    skillDetailLink: "/Skills/Detail?athleteId=0&name=" + data[i].name
                }

                self.allSkills.push(skill);
            }
        }).fail(function (jqXHR, status) {
            console("Request failed: " + status);
        });
    }
    
}

var queries = {};
$.each(document.location.search.substr(1).split('&'), function (c, q) {
    var i = q.split('=');
    queries[i[0].toString()] = i[1].toString();
});

$(function() {
    ko.applyBindings(SkillListViewModel);
    SkillListViewModel.getAllSkills();
});

