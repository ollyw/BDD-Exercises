(function(namespace) {

    function setAllArrayValues(array, value) {
        var index,
            length = array.length;
            
        for (index = 0; index < length; index++) {
            array[index] = value;
        }
    }
    
    function FirstToGame(options) {
        this.options = options;
        this.playerScores = [this.options.numberOfPlayers];
        setAllArrayValues(this.playerScores, 0);
    }

    FirstToGame.prototype.registerWinForPlayer = function(playerNumber) {
        var index = playerNumber - 1;
    
        this.playerScores[index]++;
        
        if (this.playerScores[index] == this.options.winningScore) {
            if (this.options.gameOverCallback) {
                this.options.gameOverCallback();
            }
        }
    };

    namespace.FirstToGame = FirstToGame;
})(window);
