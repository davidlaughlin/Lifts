function SkillViewModel() {
    var self = this;

    self.name = ko.observable('david');
    self.progress = ko.observable(90);

    self.skills =
    [
        { firstName: 'Bert', lastName: 'Bertington' },
        { firstName: 'Charles', lastName: 'Charlesforth' },
        { firstName: 'Denise', lastName: 'Dentiste' }
    ];
}

ko.applyBindings(new SkillViewModel());