using System;


class Player{
    public int health;
    public int sp;
    public string skill;


    public void setClass(int i){
        switch(i){
            case 1:
                health = 50;
                sp = 15;
                skill = "Slash";
                break;
            case 2:
                health = 36;
                sp = 35;
                skill = "Magic Missle";
                break;
            case 3:
                health = 43;
                sp = 25;
                skill = "Snipe shot";
                break;
        }

    }





}