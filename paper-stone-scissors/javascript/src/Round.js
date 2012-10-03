(function(namespace) {

    function Round(options) {
    }

    Round.prototype.registerChoice = function(id, choice) {
    };


    Round.prototype.selectWinner = function() {
        return 1;
    };
    
    namespace.Round = Round;
})(window);
