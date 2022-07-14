using System;


namespace ProjectZero{

    class Score{
        private int totalscore;
        public int healthscore;

        public int basescore = 500;

        public void calculateScore(Dragon enemy, Player player){
            decimal hp = (decimal) player.getHealth()/(decimal) player.getMaxHealth();
            this.healthscore = (int) (hp *100);
            if(this.healthscore<0){
                this.healthscore = 0;
            }
            this.totalscore = basescore + this.healthscore;
            bool trueending = (enemy.GetHealth() <=0 && player.getHealth()>0);
            bool badending = (enemy.GetHealth() >0 && player.getHealth()<=0);
            if(trueending){
                Console.WriteLine("\nYou stand on top of the defeated dragon's body with all the gold knowing the town is safe. \nYOU WIN!");
                Console.WriteLine("\nEnding Bonus:{0}\nHealth Bonus:{1}\nTotal Score:{3}",basescore,this.healthscore,this.totalscore);
            }
            else if(badending){
                this.totalscore -= basescore;
                basescore =0;
                Console.WriteLine("\nThe dragon consumes you and burns the town to ashes. \nYOU DIED");
                Console.WriteLine("\nEnding Bonus:{0}\nHealth Bonus:{1}\nTotal Score:{3}",basescore,this.healthscore,this.totalscore);
                
            }
            else{
                Console.WriteLine("\nAs you and the dragon collide in one final blow, the town is saved but at the cost of your own life. \nYou Win?");
                Console.WriteLine("\nEnding Bonus:{0}\nHealth Bonus:{1}\nTotal Score:{3}",basescore,this.healthscore,this.totalscore);
            }   
        }
    }

}