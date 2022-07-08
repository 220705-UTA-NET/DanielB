using System;


class Player{
    Random rand = new Random();
    public int health;
    public int maxhealth;
    public int sp;
    public int dmglow;
    public int dmghigh;
    public string skill;
    public int skilldmglow;
    public int skilldmghigh;

    public int healthpot = 3;
    


    public void setClass(int i){
        switch(i){
            case 1:
                health = 50;
                maxhealth = 50;
                sp = 15;
                skill = "Slash";
                dmglow = 10;
                dmghigh = 12;
                skilldmglow = 10;
                skilldmghigh = 12;
                break;
            case 2:
                health = 36;
                maxhealth = 36;
                sp = 35;
                skill = "Magic Missle";
                dmglow = 4;
                dmghigh = 6;
                skilldmglow = 21;
                skilldmghigh = 30;
                break;
            case 3:
                health = 43;
                maxhealth = 43;
                sp = 25;
                skill = "Snipe shot";
                dmglow = 7;
                dmghigh = 9;
                skilldmglow = 11;
                skilldmghigh = 14;
                break;
        }
        
        
        

    }
    public int attack(){
        return rand.Next(dmglow,dmghigh +1);
    }

    public int skillattack(){
        if(sp!= 0){
            sp -= 5;
            return rand.Next(skilldmglow,skilldmghigh +1);
        }
        return 0;
    }

    public void heal(){
        if(healthpot > 0){
           healthpot -=1; 
           if(health + 15 > maxhealth){
            health = maxhealth;
           }
           else{
            health +=15;
           }
        }
    }    


}