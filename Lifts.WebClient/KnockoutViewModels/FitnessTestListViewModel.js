function load(model) {
    
    $(function() {
        var viewModel = ko.mapping.fromJS(model);

        viewModel.skillProgress = ko.computed(function () {
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
        }, viewModel);

        viewModel.saveFitnessTest = function (index, data, event) {
            var self = this;
            var idx = index();

            var fitnessTest = {
                id: self.allFitnessTests()[idx].id(),
                name: self.allFitnessTests()[idx].name(),
                completed: self.allFitnessTests()[idx].completed()
            };

            $.ajax({
                url: "/Athlete/SaveFitnessTest?athleteId=" + queries["athleteId"],
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
        }

        viewModel.onCheckBoxClick = function (index, data, event) {
            var self = this;
            return self.saveFitnessTest(index, data, event);
        }

        ko.applyBindings(viewModel);
    });
}
