        public void WebNumSet() //To use this code you must also add an InTrade Variable to tell the bot if it is intrade or not.
        {
            string nventoryKeys = InventoryKeys.ToString();
            string nventoryMetal = String.Format("{0:0}", (InventoryMetal / SellPricePerKey));
            File.WriteAllText("/var/www/Steambot_Webpage/BotInfo/Invkey" + Bot.DisplayName + ".shtml", "<html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"../Main.css\"></head><body><div class=\"updating\">" + nventoryKeys + "</div><body></html>");
            Bot.log.Success("Changed Website number of keys in inventory to " + nventoryKeys);
            File.WriteAllText ("/var/www/Steambot_Webpage/BotInfo/Invmetal" + Bot.DisplayName + ".shtml", "<html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"../Main.css\"></head><body><div class=\"updating\">" + nventoryMetal + "</div><body></html>");
            Bot.log.Success("Changed Website amount of metal in inventory to " + nventoryMetal);
        }

        public void WebStatSet()
        {
            if (InTrade == 0)
            {
                File.WriteAllText ("/var/www/Steambot_Webpage/BotInfo/state" + Bot.DisplayName + ".shtml","<html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"../Main.css\"></head><body><div class=\"updating\">Looking to Trade</div><body></html>");
                Bot.log.Success("Changed state to \"Looking to Trade\".");
            }
            else if (InTrade == 1)
            {
                File.WriteAllText ("/var/www/Steambot_Webpage/BotInfo/state" + Bot.DisplayName + ".shtml", "<html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"../Main.css\"></head><body><div class=\"updating\">Busy</div><body></html>");
                Bot.log.Success("Changed state to \"Busy\".");
            }
        }