function SkillViewModel() {
    var self = this;

    self.name = ko.observable('david');
    self.progress = ko.observable(90);

    self.skills =
    [
        { name: 'Speed', progress: 29 },
        { name: 'Balance', progress: 50 },
        { name: 'Agility', progress: 35 },
        { name: 'Strength', progress: 45 }
    ];
}

ko.applyBindings(new SkillViewModel());