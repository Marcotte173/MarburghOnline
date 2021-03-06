﻿using System;
using System.Collections.Generic;
using System.Text;

public class Bank
{
    public static void Go()
    {
        Utilities.Clear();
        Write.Line("You walk in to the Marbugh National Bank");
        Write.Line("Gwenson the hobbit motions to you from behind his till");
        Write.Line("Greetings! How can I help you today?");
        DisplayBankInfo();       
        Utilities.JumpY(23);
        Write.Line("[1] Deposit");
        Write.Line("[2] Withdraw");
        if(Player.p.investmentTerm <=0) Write.Line("[3] Invest");
        else Write.Line(Color.MITIGATION, "[X] ", "You already have an investment", "");
        if (Player.p.loanTerm <= 0) Write.Line("[4] Loan");
        else Write.Line(Color.MITIGATION, "[X] ", "You already have a loan", "");
        Write.Line("[0] Return to town");
        Write.Line("[*] This is a robbery!");
        Utilities.Input();
        Utilities.Clear();
        if(Utilities.input == "1")
        {
            DisplayBankInfo();
            Write.Line("Gwenson eyes you greedily");
            Write.Line("How much would you like to deposit?");
            Utilities.NewLine(2);
            Utilities.LongInput();
            int deposit;
            if (Int32.TryParse(Utilities.input, out deposit))
            {
                if (Player.p.gold >= deposit)
                {
                    Utilities.Clear();
                    Write.Line("'Thank you for you business'");
                    Write.Line("Gwenson takes you money and deposits it into your account");
                    Player.p.gold -= deposit;
                    Player.p.goldInBank += deposit;
                    World.bankGold += deposit;
                    Utilities.Keypress();
                }
                else
                {
                    Write.Line("You don't have that much gold!");
                    Utilities.Keypress();
                }
            }
            else Go();
        }
        else if (Utilities.input == "2")
        {
            DisplayBankInfo();
            Write.Line("Gwenson looks disapointed");
            Write.Line("How much would you like to withdraw?");
            Utilities.NewLine();
            Utilities.LongInput();
            int withdrawl;
            if (Int32.TryParse(Utilities.input, out withdrawl))
            {
                if (Player.p.goldInBank >= withdrawl)
                {
                    Utilities.Clear();
                    Write.Line("'I hope you change your mind soon'");
                    Write.Line("Gwenson takes you money and deposits it into your account");
                    Player.p.gold += withdrawl;
                    Player.p.goldInBank -= withdrawl;
                    World.bankGold -= withdrawl;
                    Utilities.Keypress();
                }
                else
                {
                    Write.Line("You don't have that much gold in the bank!");
                    Utilities.Keypress();
                }
            }
        }
        else if (Utilities.input == "3"&& Player.p.investmentTerm <= 0)
        {
            DisplayBankInfo();
            Write.Line("Gwenson looks at you excitedly");
            Write.Line($"An investment will pay out {World.bankInterest * 2} of your investment in 5 days");
            Write.Line("How much would you like to invest?");
            Utilities.NewLine();
            Utilities.LongInput();
            int invest;
            if (Int32.TryParse(Utilities.input, out invest))
            {
                if (Player.p.gold >= invest)
                {
                    Utilities.Clear();
                    Write.Line("'Wonderful. Come back in 5 days to see how your investments have done'");
                    Player.p.gold -= invest;
                    Player.p.investment = invest;
                    Player.p.investmentTerm = 5;
                }
                else
                {
                    Write.Line("You don't have that much gold!");
                    Utilities.Keypress();
                }
            }
        }
        else if (Utilities.input == "4" && Player.p.loanTerm <= 0)
        {
            int maxLoan = Player.p.level * 250;
            DisplayBankInfo();
            Write.Line("Gwenson gives you a sly look");
            Write.Line($"We are prepared to loan you {maxLoan} gold.");
            Write.Line("How much would you like to borrow?");            
            Utilities.NewLine();
            Utilities.LongInput();
            int loan;
            if (Int32.TryParse(Utilities.input, out loan))
            {
                if (loan >= maxLoan)
                {
                    Utilities.Clear();
                    Write.Line("'Sounds good, this is due back in 5 days'");
                    Player.p.gold += loan;
                    Player.p.loan = loan;
                    Player.p.loanTerm = 3;
                }
                else
                {
                    Write.Line("You can't borrow that much gold!");
                    Utilities.Keypress();
                }
            }
        }
        else if (Utilities.input == "*")
        {
            Write.Line("This has not been implemented yet");
            Utilities.Keypress();
        }
        else if (Utilities.input == "0") Town.Go();
        Go();
    }

    private static void DisplayBankInfo()
    {
        Write.Line(90,0,"Gold in bank: " + Player.p.goldInBank);
        Write.Line(90,1,"Gold on hand: " + Player.p.gold);
        Write.Line(90, 3, "Interest Rate: " + World.bankInterest);
        Write.Line(90, 5, "Investments: " + Player.p.investment);
        Write.Line(90, 6, "Investment term: " + Player.p.investmentTerm);        
        Write.Line(90, 8, "Loan: " + Player.p.loan);
        Write.Line(90, 9, "Loan term: " + Player.p.loanTerm);
        Utilities.ResetCursor();
    }
}