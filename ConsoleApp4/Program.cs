using System.Collections.Generic;

namespace ConsoleApp4
{
    internal class Program
    {
        private static Character player;

        static Item[] Inventory = new Item[4];  //아이템 변수 작성 고민하기, 배열 하나 더 만들기




        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }


        static void GameDataSetting()
        {
            player = new Character("IAK", "전사", 1, 10, 5, 100, 1500);

            Item item0;
            item0.Name = "나무갑옷";
            item0.Age = player.Def + 5; //능력치가 다 더해져서 출력되는 오류 있음
            
            Item item1;
            item1.Name = "낡은검";
            item1.Age = player.Atk + 3;
            
            Item item2;
            item2.Name = "나무창";
            item2.Age = player.Atk + 4;
            
            Item item3;
            item3.Name = "체력포션"; //소모품처리 하는법?
            item3.Age = player.Hp + 75;

            Inventory[0] = item0;
            Inventory[1] = item1;
            Inventory[2] = item2;
            Inventory[3] = item3;

            Inventory[0].PrintInfo(); // 출력 for 문에서 순회하는 명령어 출력가능
            Inventory[1].PrintInfo();
            Inventory[2].PrintInfo();
            Inventory[3].PrintInfo();
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 던전입장"); // 놀랍게도 던전없는 RPG!
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    DisplayInventory();
                    break;
                    //case 3: 던전입장
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        struct Item
        {
            public string Name;
            public int Age;

            public void PrintInfo()
            {
                Console.WriteLine($"능력치가 증가하였습니다.");
            }


           
        }

        static void DisplayInventory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("캐릭터의 인벤토리를 표시합니다.");
            
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Inventory[i].Name); //아이템 이름 for문으로 구현
            }    
            
            Console.WriteLine("1. 장착하기");
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;


                case 1:
                    DisplayInveneq();
                    break;
            }

        }

        static void DisplayInveneq()
        {
            Console.Clear();

            Console.WriteLine("장비장착");
            Console.WriteLine("캐릭터의 장비장착 상태를 표시합니다.");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(i + 1 + "." + Inventory[i].Name);
            }

            Console.WriteLine("0. 나가기");
            Console.WriteLine("4. 인벤토리");

            int input = CheckValidInput(0, 4);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;

                case 1:
                    // bool 코드를 활용하여 아이템 장착기능 (true, false 활용)
                    break;

                case 2:
                    
                    break;

                case 3:
                    
                    break;

                case 4:
                    DisplayInventory();
                    break;
            }

        }

        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }




    }

        


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }  
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}