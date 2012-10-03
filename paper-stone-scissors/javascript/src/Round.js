(function(namespace) {
  
  function beats(choice1, choice2) {
    if (choice1 === choice2)
      return false;
      
    if (choice1 === 'paper' && choice2 === 'stone')
      return true;
      
    if (choice1 === 'stone' && choice2 === 'scissors')
      return true;
      
    if (choice1 === 'scissors' && choice2 === 'paper')
      return true;
      
    return false;
  }
  
  function Round(options) {
    this.choices = [];
  }

  Round.prototype.registerChoice = function(id, choice) {
    this.choices.push({ id: id, choice: choice });
  };


  Round.prototype.getRanking = function() {
    var i, j, loser,
      winners = [],
      losers = [],
      rank = [];
    
    for(i = 0; i < this.choices.length; i++) {
      loser = false;
      for(j = 0; j < this.choices.length; j++) {
        if (i !== j) {
          if (beats(this.choices[j].choice, this.choices[i].choice)) {
            loser = true;
            break;
          }
        }
      }
      if (loser) {
        losers.push(this.choices[i].id);
      } else {
        winners.push(this.choices[i].id);
      }
    }
    
    if (winners.length > 0) {
      rank.push(winners);
    }
    
    if (losers.length > 0) {
      rank.push(losers);
    }
    
    return rank;
  };
    
  namespace.Round = Round;
})(window);
