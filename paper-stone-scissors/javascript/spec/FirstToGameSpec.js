describe("FirstToGame", function() {
    describe("Creating a Game", function() {
       it("should only allow games that have 2 or more players", function() {
          
          expect(function () { 
                 new FirstToGame({
                                 numberOfPlayers: 0
                                 });
                 }).toThrow('Game must have at least 2 players');
       });
       
       it("should only allow winning scores greater than 0", function() {
          
          expect(function () { 
                 new FirstToGame({
                                 numberOfPlayers: 2,
                                 winningScore: 0
                                 });
                 }).toThrow('Game must have at winning scores greater than 0');
          
          expect(function () { 
                 new FirstToGame({
                                 numberOfPlayers: 2,
                                 winningScore: -1
                                 });
                 }).toThrow('Game must have at winning scores greater than 0');
       });
   });
         
  describe("Game Over Callback", function() {
      it("should fire when one player scores the winning score", function() {
        var gameOverCallback = jasmine.createSpy();
        
        var game = new FirstToGame({
            winningScore: 3,
            numberOfPlayers: 2,
            gameOverCallback: gameOverCallback
        });
        
        game.registerWinForPlayer(1);
        expect(gameOverCallback).not.toHaveBeenCalled();
        
        game.registerWinForPlayer(1);
        expect(gameOverCallback).not.toHaveBeenCalled();
        
        game.registerWinForPlayer(2);
        expect(gameOverCallback).not.toHaveBeenCalled();
        
        game.registerWinForPlayer(1);
        expect(gameOverCallback).toHaveBeenCalled();
      });
   });
   
   describe("Registering a Win for Player", function() {
      it("should not allow any further scores after completion", function() {
        var game = new FirstToGame({
            winningScore: 1,
            numberOfPlayers: 2
        });
        
        game.registerWinForPlayer(1);
        
        expect(function () { game.registerWinForPlayer(1); }).toThrow('Game Over');
      });
   });
 });