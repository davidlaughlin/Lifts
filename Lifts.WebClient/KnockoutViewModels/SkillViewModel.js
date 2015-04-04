function SkillViewModel() {
    var self = this;

    self.name = ko.observable('Some Skill');
    self.progress = ko.observable(0);

    self.skills =
    [
        { name: 'Cardiovascular', progress: 14 },
        { name: 'Stamina', progress: 35 },
        { name: 'Strength', progress: 45 },
        { name: 'Flexibility', progress: 29 },
        { name: 'Power', progress: 65 },
        { name: 'Speed', progress: 9 },
        { name: 'Coordination', progress: 3 },
        { name: 'Agility', progress: 100 },
        { name: 'Balance', progress: 82 },
        { name: 'Accuracy', progress: 99 }
    ];
}

ko.applyBindings(new SkillViewModel());