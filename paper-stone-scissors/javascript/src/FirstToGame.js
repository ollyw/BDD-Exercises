(function(namespace) {

    function setAllArrayValues(array, value) {
        var index,
            length = array.length;
            
        for (index = 0; index < length; index++) {
            array[index] = value;
        }
    }
    
    function validateOptions(options)
    {
        if (typeof options.numberOfPlayers !== 'number'
            || options.numberOfPlayers < 2) {
                throw 'Game must have at least 2 players';
            }
            
        if (typeof options.winningScore !== 'number'
            || options.winningScore < 1) {
                throw 'Game must have at winning scores greater than 0';
            }
    }
    
    function FirstToGame(options) {
        
        validateOptions(options);
        
        this.options = options;
        this.completed = false;
        
        this.playerScores = [this.options.numberOfPlayers];
        setAllArrayValues(this.playerScores, 0);
    }

    FirstToGame.prototype.registerWinForPlayer = function(playerNumber) {
        if (this.completed) {
            throw 'Game Over';
        }
        
        var index = playerNumber - 1;
    
        this.playerScores[index]++;
        
        if (this.playerScores[index] === this.options.winningScore) {
            this.completed = true;
            if (this.options.gameOverCallback) {
                this.options.gameOverCallback();
            }
        }
    };

    namespace.FirstToGame = FirstToGame;
})(window);
