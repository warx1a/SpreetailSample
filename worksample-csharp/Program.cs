using System;
using System.Linq;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string invalidParamsMessage = "An invalid number of parameters were passed for this action.";
            MultiValueDictionary dictToUse = new MultiValueDictionary();

            while(true) {
                Console.Write(">");
                string input = Console.ReadLine();
                Action inputtedAction = ParseInputToAction(input);
                Console.WriteLine("You entered: " + input);
                switch (inputtedAction.ActionName)
                {
                    case "HELP":
                        Console.WriteLine(GetHelpMenu());
                        break;
                    case "ADD":
                        if(inputtedAction.Params.Count != 2 || inputtedAction.Params.Any((param) => string.IsNullOrWhiteSpace(param)))
                        {
                            Console.WriteLine(invalidParamsMessage);
                        } else
                        {
                            Console.WriteLine(dictToUse.Add(inputtedAction.Params[0], inputtedAction.Params[1]));
                        }
                        break;
                    case "REMOVE":
                        if (inputtedAction.Params.Count != 2 || inputtedAction.Params.Any((param) => string.IsNullOrWhiteSpace(param)))
                        {
                            Console.WriteLine(invalidParamsMessage);
                        }
                        else
                        {
                            Console.WriteLine(dictToUse.Remove(inputtedAction.Params[0], inputtedAction.Params[1]));
                        }
                        break;
                    case "MEMBERS":
                        if(inputtedAction.Params.Count != 1 || inputtedAction.Params.Any((param) => string.IsNullOrWhiteSpace(param)))
                        {
                            Console.WriteLine(invalidParamsMessage);
                        } else
                        {
                            Console.WriteLine(dictToUse.Members(inputtedAction.Params[0]));
                        }
                        break;
                    case "KEYS":
                        Console.WriteLine(dictToUse.Keys());
                        break;
                    case "REMOVEALL":
                        if(inputtedAction.Params.Count != 1 || inputtedAction.Params.Any((param) => string.IsNullOrWhiteSpace(param)))
                        {
                            Console.WriteLine();
                        } else
                        {
                            Console.WriteLine(dictToUse.RemoveAll(inputtedAction.Params[0]));
                        }
                        break;
                    case "CLEAR":
                        Console.WriteLine(dictToUse.Clear());
                        break;
                    case "ALLMEMBERS":
                        Console.WriteLine(dictToUse.AllMembers());
                        break;
                    case "MEMBEREXISTS":
                        if(inputtedAction.Params.Count != 2 || inputtedAction.Params.Any((param) => string.IsNullOrWhiteSpace(param)))
                        {
                            Console.WriteLine(invalidParamsMessage);
                        } else
                        {
                            Console.WriteLine(dictToUse.MemberExists(inputtedAction.Params[0], inputtedAction.Params[1]));
                        }
                        break;
                    case "KEYEXISTS":
                        if(inputtedAction.Params.Count != 1 || inputtedAction.Params.Any((param) => string.IsNullOrWhiteSpace(param)))
                        {
                            Console.WriteLine(invalidParamsMessage);
                        } else
                        {
                            Console.WriteLine(dictToUse.KeyExists(inputtedAction.Params[0]));
                        }
                        break;
                    case "ITEMS":
                        Console.WriteLine(dictToUse.Items());
                        break;
                    default:
                        Console.WriteLine("This command was not understood.");
                        break;
                }
            }
        }


        /// <summary>
        /// Holds the hardcoded help menu. This lists all the commands available.
        /// </summary>
        /// <returns>The help menu in a formatted version.</returns>
        private static string GetHelpMenu()
        {
            return $"MultiValueDictionary Commands:\n" +
                $"ADD [key] [value]\n" +
                $"REMOVE [fromKey] [value]\n" +
                $"REMOVEALL [fromKey]\n" +
                $"CLEAR\n" +
                $"ALLMEMBERS\n" +
                $"ITEMS\n" +
                $"KEYEXISTS [key]\n" +
                $"MEMBEREXISTS [inKey] [value]\n" +
                $"KEYS\n" +
                $"MEMBERS [inKey]";
        }

        private static Action ParseInputToAction(string input)
        {
            Action actionEntered = new Action();
            string[] parts = input.Split(" ");
            actionEntered.ActionName = parts[0].ToUpper();
            //not all commands have params, so set it to be an empty list if none available
            if(parts.Length > 1)
            {
                actionEntered.Params = new System.Collections.Generic.List<string>(parts.Skip(1));
            } else //no params were passed in, so set it to be an empty list
            {
                actionEntered.Params = new System.Collections.Generic.List<string>();
            }
            
            return actionEntered;
        }

    }
}
