using System;


namespace ProjectZero{

    class Score{
        private int totalscore;
        public int healthscore;

        public int speedscore;

        int[] winmusic = 
        {
            262,262,262,262,208,233,262,233,262
        };
        int[] windur = 
        {
            150,150,150,400,400,400,200,400,800
        };
        int[] losemusic = 
        {
            294,277,262,247
        };
        int[] losedur = 
        {
            400,400,400,1600
        };
        int[] dmusic = 
        {
            130,130,174,37,130,174,220,37,130,174,220,37,130,174,220,37,130,174,220,37,174,220,262,220,174,130,37,130,130,174
        };
        int[] ddur = 
        {
            600,400,1200,200,600,400,1200,200,600,400,400,200,600,400,400,200,600,400,800,200,600,400,800,400,400,1200,200,600,400,1600
        };

        public int basescore = 500;

        public void calculateScore(Dragon enemy, Player player,int count){
            decimal hp = (decimal) player.getHealth()/(decimal) player.getMaxHealth();
            this.healthscore = (int) (hp *100);
            if(this.healthscore<0){
                this.healthscore = 0;
            }
            this.speedscore = (10 - (count-1))*10;
            if(this.speedscore<0){
                this.speedscore = 0;
            }
            this.totalscore = basescore + this.healthscore + this.speedscore;
            bool trueending = (enemy.GetHealth() <=0 && player.getHealth()>0);
            bool badending = (enemy.GetHealth() >0 && player.getHealth()<=0);
            if(trueending){
                Console.WriteLine("\nYou stand on top of the defeated dragon's body with all the gold knowing the town is safe. \nYOU WIN!");
                Console.WriteLine("\nEnding Bonus:{0}\nHealth Bonus:{1}\nSpeed Bonus:{2}\nTotal Score:{3}",basescore,this.healthscore,this.speedscore,this.totalscore);
                for(int i = 0; i < winmusic.Length; i++){
                    Console.Beep(winmusic[i],windur[i]);
                }
            }
            else if(badending){
                this.totalscore = 0;
                basescore = 0;
                speedscore = 0;
                Console.WriteLine("\nThe dragon consumes you and burns the town to ashes. \nYOU DIED");
                Console.WriteLine("\nEnding Bonus:{0}\nHealth Bonus:{1}\nSpeed Bonus:{2}\nTotal Score:{3}",basescore,this.healthscore,this.speedscore,this.totalscore);
                for(int i = 0; i < losemusic.Length; i++){
                    Console.Beep(losemusic[i],losedur[i]);
                }
                
            }
            else{
                Console.WriteLine("\nAs you and the dragon collide in one final blow, the town is saved but at the cost of your own life. \nYou Win?");
                Console.WriteLine("\nEnding Bonus:{0}\nHealth Bonus:{1}\nSpeed Bonus:{2}\nTotal Score:{3}",basescore,this.healthscore,this.speedscore,this.totalscore);
                for(int i = 0; i < dmusic.Length; i++){
                    if(dmusic[i]==37){
                        Thread.Sleep(ddur[i]);
                    }
                    else{
                        Console.Beep(dmusic[i],ddur[i]);
                    }
                    
                }
            }   
        }
    }

}