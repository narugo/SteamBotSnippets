        //Part 1
		public void comet(int cid) //stands for combine metal
        {
            List<ulong> metal = new List<ulong>(); // we will store the scrap IDs here
            Bot.GetInventory();
            foreach (var item in Bot.MyInventory.Items)
            {
                if (metal.Count == 3)
                    break; // stop looking for more scrap metal when we already have 3
                if (item.Defindex == cid && !metal.Contains(item.Id))
                    metal.Add(item.Id); // This code checks to make sure ID doesn't exist already, then adds to list
            }
            if (metal.Count == 3)
            {
                Bot.SetGamePlaying(440);
                Crafting.CraftItems(Bot, metal.ToArray()); // Here we transform the list object into an array
                // Update bot's inventory
                Bot.GetInventory();
                Bot.SetGamePlaying(0);
                Bot.log.Success("Crafted metal together");
            }
        }

        public void mkmet (int cid) //stands for make metal
        {
            ulong metal = 0;
            bool found = false;
            Bot.GetInventory ();
            foreach (var item in Bot.MyInventory.Items)
            {
                if (found)
                    break; // stop looking for more scrap metal when we already have 3
                if (item.Defindex == cid)
                    metal = item.Id; // This code checks to make sure ID doesn't exist already, then adds to list
            }
            if (found)
            {
                Bot.SetGamePlaying (440);
                Crafting.CraftItems (Bot, metal); // Here we transform the list object into an array
                // Update bot's inventory
                Bot.GetInventory ();
                Bot.SetGamePlaying (0);
                Bot.log.Success ("Crafted more metal");
            }
            else
            {
                Bot.log.Error("Error in mkmet command");
            }
        }
		//Part 2
        public void TradeCountInventory (bool message) //Edited TradeCountInventory
        {
            // Let's count our inventory
            Inventory.Item[] inventory = Trade.MyInventory.Items;
            InventoryMetal = 0;
            InventoryKeys = 0;
            InventoryRef = 0;
            InventoryRec = 0;
            InventoryScrap = 0;
            foreach (Inventory.Item item in inventory)
            {
                if (item.Defindex == 5000)
                {
                    InventoryMetal++;
                    InventoryScrap++;
                }
                else if (item.Defindex == 5001)
                {
                    InventoryMetal += 3;
                    InventoryRec++;
                }
                else if (item.Defindex == 5002)
                {
                    InventoryMetal += 9;
                    InventoryRef++;
                }
                else if (item.Defindex == 5021)
                {
                    InventoryKeys++;
                }
            }
            if (message)
            {
                double MetalToRef = (InventoryMetal / 9.0) - 0.01;
                string refined = string.Format ("{0:N2}", MetalToRef);
                Trade.SendMessage ("Current stock: I have " + refined + " ref (" + InventoryRef + " ref, " + InventoryRec + " rec, and " + InventoryScrap + " scrap) and " + InventoryKeys + " key(s) in my backpack.");
                Bot.log.Success ("Current stock: I have " + refined + " ref (" + InventoryRef + " ref, " + InventoryRec + " rec, and " + InventoryScrap + " scrap) and " + InventoryKeys + " key(s) in my backpack.");
            }
            if(InventoryScrap >= 5)
            {
                comet(5000);
                Bot.log.Debug("scrap");
                TradeCountInventory(false);
            }

            if(InventoryRec >= 6)
            {
                comet(5001);
                Bot.log.Debug("rec");
                TradeCountInventory(false);
            }

			if(InventoryRec <= 2)
            {
                mkmet(5002);
				TradeCountInventory(false);
            }
			
            if(InventoryScrap <= 1)
            {
                mkmet(5001);
				TradeCountInventory(false);
            }


            WebNumSet();
            HasCounted = true;
        }