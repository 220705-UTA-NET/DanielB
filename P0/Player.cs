using System;


class Player{
    public int health;
    public int sp;
    public int dmglow;
    public int dmghigh;
    public string skill;
    public int skilldmglow;
    public int skilldmghigh;
    


    public void setClass(int i){
        switch(i){
            case 1:
                health = 50;
                sp = 15;
                skill = "Slash";
                dmglow = 10;
                dmghigh = 12;
                skilldmglow = 10;
                skilldmghigh = 12;
                break;
            case 2:
                health = 36;
                sp = 35;
                skill = "Magic Missle";
                dmglow = 4;
                dmghigh = 6;
                dmglow = 7;
                dmghigh = 10;
                break;
            case 3:
                health = 43;
                sp = 25;
                skill = "Snipe shot";
                dmglow = 7;
                dmghigh = 9;
                skilldmglow = 11;
                skilldmghigh = 14;
                break;
        }

    }





}