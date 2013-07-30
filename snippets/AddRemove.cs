            else if (IsAdmin) //Put this in the TRADE window messages area
            {
                if (message.StartsWith(".add"))
                {
                    if (message.Substring(5) == "key")
                    {
                        AdminItem = 5021;
                    }
                    else if (message.Substring(5) == "scrap")
                    {
                        AdminItem = 5000;
                    }
                    else if (message.Substring(5) == "rec")
                    {
                        AdminItem = 5001;
                    }
                    else if (message.Substring(5) == "ref")
                    {
                        AdminItem = 5002;
                    }
                    else
                    {
                        int.TryParse(message.Substring(5), out AdminItem);
                    }
                    Trade.AddItemByDefindex(AdminItem);
                }
                else if (message.StartsWith(".remove"))
                {
                    if (message.Substring(8) == "key")
                    {
                        AdminItem = 5021;
                    }
                    else if (message.Substring(8) == "scrap")
                    {
                        AdminItem = 5000;
                    }
                    else if (message.Substring(8) == "rec")
                    {
                        AdminItem = 5001;
                    }
                    else if (message.Substring(8) == "ref")
                    {
                        AdminItem = 5002;
                    }
                    else
                    {
                        int.TryParse(message.Substring(8), out AdminItem);
                    }
                    Trade.RemoveItemByDefindex(AdminItem);
                }
            }