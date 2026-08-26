using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_RandomItemDrop();
            AS02_NestedLoopForCreate2DMap();
            AS03_NestedLoopForMakingWallAround();
            // AS04_AttackEnemy();
            // AS05_DynamicIterationLoop();
            // AS06_WhileLoopAndArray();
            // AS07_HealTargetAtIndex();
            // AS08_RandomPickingDialogue();
            // AS09_MultiplicationTable();
            // AS10_FindSummationFromZeroToNUsingWhileLoop();
            // AS11_SpawnEnemies();
            // StartCoroutine(AS12_CountTime());
            // AS13_SumOfNumbersInRow();
            // AS14_SumOfNumbersInColumn();
            // AS15_MakeTheTriangle();
            // AS16_MultiplicationTableOf_2_3_and_4();
            // EX_01_TicTacToeGame_TurnPlay();

        }

        #region Assignment

        /*
         * จงเขียนโปรแกรมเพื่อสุ่มการดรอปไอเท็ม
         * จากรายการของไอเท็ม (GameObject[] items) ที่กำหนดให้ และสร้างวัตถุ (Instantiate) จากรายการที่ถูกเลือกสุ่มนั้น
         * และพิมพ์ชื่อออกมาทางคอนโซล (field name)
         * ตัวอย่างเช่น
         * Debug.Log($"Got item: {go.name}");
         *
         * พารามิเตอร์:
         * - items: รายการของ GameObject ไอเท็มทั้งหมดที่จะสุ่มดรอป
         */
        [Header("AS01_RandomItemDrop")]
        public GameObject[] as01_items;
        public void AS01_RandomItemDrop()
        {
            int randomed = UnityEngine.Random.Range(0, as01_items.Length);
            Debug.Log(as01_items[randomed]);
        }

        /*
         * จงเขียนโปรแกรมใน Unity C# เพื่อสร้างแผนที่ 2D โดยใช้ Nested Loop
         * กำหนดขนาด: กำหนดจำนวนคอลัมน์ (columns) และจำนวนแถว (rows) ของพื้นที่เล่น
         * โดยกำหนดให้ มีตัวแปรดังนี้
         * public int columns = 5;
         * public int rows = 5;
         *
         * สร้างวัตถุแบบสุ่ม: เลือกวัตถุพื้น (floorTiles) จากอาร์เรย์แบบสุ่มในแต่ละตำแหน่ง โดยกำหนดให้ มีตัวแปรดังนี้
         * public GameObject[] floorTiles;
         *
         * โดยที่เมื่อ program run ระบบจะกำหนดค่าใน array มาให้ 3 GameObject โดยแต่ละ GameObject มีชื่อดังนี้
         * 1 แทนพื้นแบบที่ 1
         * 2 แทนพื้นแบบที่ 2
         * 0 แทนพื้นธรรมดา
         *
         * วางวัตถุ: วางวัตถุที่เลือกไว้ในตำแหน่งที่กำหนด โดยใช้ฟังก์ชัน Instantiate และกำหนดตำแหน่งผ่าน index ของ X Y ลงใน Vector2
         * GameObject tile = Instantiate(obj, new Vector2(x, y), transform.rotation);
         *
         * และให้พิมพ์ชื่อของ GameObject tile ออกมาเพื่อแสดง pattern ของ map ที่ random สุ่มพื้นออกมาได้ ด้วย code
         * Console.Write(tile.name);
         *
         * ตัวอย่างผลลัพธ์:
         *
         * Case 1: สร้าง map ขนาด 3x3 และสุ่มพื้นได้เป็น pattern
         * Column ...
         * 3
         * Row ...
         * 3
         * 211
         * 110
         * 000
         *
         * Case 2: สร้าง map ขนาด 10x10 และสุ่มพื้นได้เป็น pattern
         * Column ...
         * 10
         * Row ...
         * 10
         * 0100221122
         * 2011120022
         * 0210021000
         * 2010112011
         * 2001101221
         * 0002200210
         * 1221002122
         * 2001102001
         * 2200122110
         * 1101112120
         *
         * พารามิเตอร์:
         * - floorTiles: อาร์เรย์ของ GameObject พื้นแบบต่างๆ
         * - columns: จำนวนคอลัมน์ของแผนที่
         * - rows: จำนวนแถวของแผนที่
         */
        [Header("AS02_NestedLoopForCreate2DMap")]
        public GameObject[] as02_floorTiles;
        public int as02_columns;
        public int as02_rows;
        public void AS02_NestedLoopForCreate2DMap()
        {
            for (int x = 0; x < as02_columns; x++)
            {
                string logStr = "";
                for (int y = 0; y < as02_rows; y++)
                {
                    int randomed = UnityEngine.Random.Range(0, as02_floorTiles.Length);
                    GameObject tile = Instantiate(as02_floorTiles[randomed], new Vector2(x, y), transform.rotation);
                    if (tile.TryGetComponent<SpriteRenderer>(out var sr))
                    {
                        sr.sortingOrder = 0;
                    }
                    logStr += randomed.ToString();
                }
                Debug.Log(logStr);
            }

        }

        /*
         * จงเขียนโปรแกรมใน Unity C# เพื่อสร้างกำแพงรอบนอก โดยใช้ Nested Loop
         * กำหนดขนาด: กำหนดจำนวนคอลัมน์ (columns) และจำนวนแถว (rows) ของพื้นที่เล่น
         * โดยกำหนดให้มีตัวแปรดังนี้
         *
         * public int columns = 5;
         * public int rows = 5;
         *
         * สร้างวัตถุกำแพง: (Wall) ในตัวแปร GameObject
         * โดยกำหนดให้มีตัวแปรดังนี้
         *
         * public GameObject wall;
         *
         * ซึ่งเมื่อโปรแกรมเริ่ม ระบบจะกำหนดให้ GameObject wall มีชื่อ "*"
         *
         * วางกำแพง: ไว้ในตำแหน่ง X -1 : Y -1 และ columns +1 : rows +1 โดยใช้ฟังก์ชัน Instantiate และกำหนดตำแหน่งผ่าน index ของ X Y ลงใน Vector2
         * if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1) {
         *     Instantiate(wall, new Vector2(x, y), transform.rotation);
         * }
         *
         * ซึ่งจากเงื่อนไขดังกล่าว Pattern และเงื่อนไขของการวางตำแหน่งกำแพงจะมี 4 รูปแบบ กำหนดให้ x แทน index ของ Column และ y แทน index ของ Row
         * - ไว้ในตำแหน่งขอบบนสุด หรือ Row แรก => y == 0
         * - ไว้ในตำแหน่งขอบล่างสุด หรือ row สุดท้าย => y == rows - 1
         * - ไว้ในตำแหน่งขอบซ้ายสุด หรือ Column แรก => x == 0
         * - ไว้ในตำแหน่งขวาสุด หรือ Column สุดท้าย => x == columns - 1
         *
         * ตัวอย่างผลลัพธ์:
         *
         * Case 1
         * Column ...
         * 5
         * Row ...
         * 3
         * *******
         * *     *
         * *     *
         * *     *
         * *******
         *
         * Case 2
         * Column ...
         * 3
         * Row ...
         * 5
         * *****
         * *   *
         * *   *
         * *   *
         * *   *
         * *   *
         * *****
         *
         * Case 3
         * Column ...
         * 10
         * Row ...
         * 4
         * ************
         * *          *
         * *          *
         * *          *
         * *          *
         * ************
         *
         * Case 4 - กรณีพิเศษกำแพงวางล้อมแบบไม่มีช่องว่างตรงกลางเลย
         * Column ...
         * 2
         * Row ...
         * 2
         * ****
         * *  *
         * *  *
         * ****
         *
         * ตรวจสอบขอบ:
         * if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1) เป็นเงื่อนไขที่ตรวจสอบว่าตำแหน่งปัจจุบัน (x, y) อยู่ที่ขอบของพื้นที่หรือไม่
         * columns และ rows เป็นตัวแปรที่กำหนดขนาดของพื้นที่เล่น
         * x == 0 หรือ x == columns - 1 ตรวจสอบว่าตำแหน่งอยู่ที่ขอบซ้ายหรือขวา
         * y == 0 หรือ y == rows - 1 ตรวจสอบว่าตำแหน่งอยู่ที่ขอบบนหรือล่าง
         *
         * พารามิเตอร์:
         * - wall: GameObject/Prefab กำแพง
         * - columns: จำนวนคอลัมน์ของพื้นที่เล่น
         * - rows: จำนวนแถวของพื้นที่เล่น
         */
        [Header("AS03_NestedLoopForMakingWallAround")]
        public GameObject as03_wall;
        public int as03_columns;
        public int as03_rows;
        public void AS03_NestedLoopForMakingWallAround()
        {
            for (int x = 0; x < as03_columns; x++)
            {
                for (int y = 0; y < as03_rows; y++)
                {
                    if (x == 0 || x == as03_columns - 1 || y == 0 || y == as03_rows - 1)
                    {
                        GameObject wall = Instantiate(as03_wall, new Vector2(x, y), transform.rotation);
                        if (wall.TryGetComponent<SpriteRenderer>(out var sr))
                        {
                            sr.sortingOrder = 1;
                        }
                    }
                }
            }
        }

        /*
         * ให้นักศึกษาเขียนโปรแกรมเพื่อโจมตีเป้าหมายดังนี้
         * ตัวแปรที่เกี่ยวข้อง
         * public int[] enemyHP; array ที่เก็บ hp ของ enemy
         * public int damage; จำนวน damage ที่ user ระบุ
         * public int target; target index ของ enemy
         *
         * รูปแบบที่ 1 โจมตีตัวแรกในรายการ
         * เมื่อผู้ใช้ใส input Damage เข้ามา จะโจมตีตัวแรกเสมอ แล้วให้พิมพ์ FirstEnemy hp :<hp ที่เหลือ>
         * รูปแบบที่ 2 โจมตีตัวสุดท้ายในรายการ
         * เมื่อผู้ใช้ใส input Damage เข้ามา จะโจมตีตัวสุดท้ายเสมอ  แล้วให้พิมพ์ LastEnemy hp :<hp ที่เหลือ>
         * รูปแบบที่ 3 โจมตีตัวเป้าหมายที่กำหนด
         * เมื่อผู้ใช้ใส่ input Damage เข้ามา และ input เลือกเป้าหมายที่จะโจมตีด้วย index ของ array จากนั้นทำการโจมตีเป้าหมายที่ต้องการ  แล้วให้พิมพ์ TargetEnemy <target> hp :<hp ที่เหลือ>
         *
         * โดยที่ Program จะทำการ Attack เรียงจากรูปแบบที่ 1, 2 และ 3 ตามลำดับ
         *
         * ตัวอย่างผลลัพธ์
         * FirstEnemy hp :8
         * LastEnemy hp :8
         * TargetEnemy 3 hp :8
         *
         * พารามิเตอร์:
         * - enemyHP: array ที่เก็บค่า HP ของ enemy แต่ละตัว
         * - damage: จำนวน damage ที่จะโจมตี
         * - target: index ของ enemy เป้าหมายที่จะโจมตี (สำหรับรูปแบบที่ 3)
         */
        [Header("AS04_AttackEnemy")]
        public int[] as04_enemyHP;
        public int as04_damage;
        public int as04_target;
        public void AS04_AttackEnemy()
        {

            as04_enemyHP[0] = Mathf.Max(0, as04_enemyHP[0] - as04_damage);
            Debug.Log($"FirstEnemy hp :{as04_enemyHP[0]}");


            int lastIndex = as04_enemyHP.Length - 1;
            as04_enemyHP[lastIndex] = Mathf.Max(0, as04_enemyHP[lastIndex] - as04_damage);
            Debug.Log($"LastEnemy hp :{as04_enemyHP[lastIndex]}");


            as04_enemyHP[as04_target] = Mathf.Max(0, as04_enemyHP[as04_target] - as04_damage);
            Debug.Log($"TargetEnemy {as04_target} hp :{as04_enemyHP[as04_target]}");
        }

        /*
         * จงเขียนโปรแกรมเพื่อสร้าง for ลูป จาก 0 - (n-1)
         * โดยกำหนดให้ n รับค่าจากผู้ใช้
         * ให้ n รับค่าจำนวนเต็มจากช่องป้อนข้อมูล inputField
         * สร้างลูปซ้ำ ที่จะวนซ้ำจำนวนครั้งที่ผู้ใช้กำหนดในค่า n
         * แสดงผลลัพธ์เป็นตัวเลขที่เพิ่มขึ้นทีละ 1 เริ่มจาก 0 จนถึงค่า n-1
         * ตัวอย่าง: ถ้าผู้ใช้ป้อนค่า 5 ลงใน inputField ผลลัพธ์ที่ได้จะแสดงใน Debug Log ดังนี้:
         * 0
         * 1
         * 2
         * 3
         * 4
         *
         * พารามิเตอร์:
         * - n: ค่าจำนวนเต็มที่รับจาก inputField (จำนวนรอบที่จะวนลูป)
         */
        [Header("AS05_DynamicIterationLoop")]
        public int as05_n;
        public void AS05_DynamicIterationLoop()
        {
            for (int i = 0; i < as05_n; i++)
            {
                Debug.Log(i);
            }
        }

        /*
         * จงเขียนโปรแกรมเพื่อแสดงรายชื่อชุดเกราะ Iron Man โดยใช้ Array และ while loop
         * ให้รับอาร์เรย์ของสตริงที่เก็บชื่อชุดเกราะ เช่น:
         * [
         *     "Mark I",
         *     "Mark II",
         *     "Mark III",
         *     "Mark IV",
         *     "Mark V",
         *     "Mark VI",
         *     "Mark VII"
         * ]
         *
         * ทำสองรูปแบบโดยใช้ while loop:
         * ======Log by One======
         * while Loop ที่ 1:
         * - ให้ตัวนับ i เริ่มที่ 0 และเพิ่มครั้งละ 1 (i += 1)
         * - พิมพ์ค่าจากอาร์เรย์ตามลำดับ index 0, 1, 2, 3, ...
         *
         * ======Log by Two======
         * while Loop ที่ 2:
         * - ให้ตัวนับ i เริ่มที่ 0 และเพิ่มครั้งละ 2 (i += 2)
         * - พิมพ์ค่าจากอาร์เรย์ตาม index 0, 2, 4, 6, ...
         *
         * ตัวอย่างผลลัพธ์:
         * ======Log by One======
         * Mark I
         * Mark II
         * Mark III
         * Mark IV
         * Mark V
         * Mark VI
         * Mark VII
         * ======Log by Two======
         * Mark I
         * Mark III
         * Mark V
         * Mark VII
         *
         * พารามิเตอร์:
         * - ironManSuitNames: อาร์เรย์ของชื่อชุดเกราะ Iron Man
         */
        [Header("AS06_WhileLoopAndArray")]
        public string[] as06_ironManSuitNames;
        public void AS06_WhileLoopAndArray()
        {
            int i = 0;
            Debug.Log("======Log by One======");
            while (i < as06_ironManSuitNames.Length)
            {
                Debug.Log(as06_ironManSuitNames[i]);
                i += 1;
            }

            i = 0;
            Debug.Log("======Log by Two======");
            while (i < as06_ironManSuitNames.Length)
            {
                Debug.Log(as06_ironManSuitNames[i]);
                i += 2;
            }
        }

        /*
         * ให้นักศึกษาเขียนโปรแกรมเพื่อ Heal เป้าหมายดังนี้
         * ตัวแปรที่เกี่ยวข้อง
         *
         * public int[] heroHPs; // array ที่เก็บ hp ของ hero
         * public int heal; // จำนวน heal ที่ user ระบุ
         * public int targetIndex; // target index ของ hero
         *
         * รูปแบบที่ 1 Heal ตัวแรกในรายการ
         * เมื่อผู้ใช้ใส่ input Heal เข้ามา จะ Heal ตัวแรกเสมอ แล้วให้พิมพ์ FirstHero hp :<hp หลังจาก heal แล้ว>
         *
         * รูปแบบที่ 2 Heal ตัวสุดท้ายในรายการ
         * เมื่อผู้ใช้ใส่ input Heal เข้ามา จะ Heal ตัวสุดท้ายเสมอ แล้วให้พิมพ์ LastHero hp :<hp หลังจาก heal แล้ว>
         *
         * รูปแบบที่ 3 Heal ตัวเป้าหมายที่กำหนด
         * เมื่อผู้ใช้ใส่ input Heal เข้ามา และ input เลือกเป้าหมายที่จะ heal ด้วย index ของ array จากนั้นทำการ heal เป้าหมายที่ต้องการ แล้วให้พิมพ์ TargetHero <targetIndex> hp :<hp หลังจาก Heal แล้ว>
         *
         * โดยที่ Program จะทำการ Heal เรียงจากรูปแบบที่ 1, 2 และ 3 ตามลำดับ
         *
         * ตัวอย่างผลลัพธ์
         * FirstHero hp :8
         * LastHero hp :8
         * TargetHero 3 hp :8
         *
         * พารามิเตอร์:
         * - heroHPs: array ที่เก็บค่า HP ของ hero แต่ละตัว
         * - heal: จำนวน heal ที่จะฟื้นฟู
         * - targetIndex: index ของ hero เป้าหมายที่จะฟื้นฟู (สำหรับรูปแบบที่ 3)
         */
        [Header("AS07_HealTargetAtIndex")]
        public int[] as07_heroHPs;
        public int as07_heal;
        public int as07_targetIndex;
        public void AS07_HealTargetAtIndex()
        {
            as07_heroHPs[0] += as07_heal;
            Debug.Log($"FirstHero hp :{as07_heroHPs[0]}");

            int lastIndex = as07_heroHPs.Length - 1;
            as07_heroHPs[lastIndex] += as07_heal;
            Debug.Log($"LastHero hp :{as07_heroHPs[lastIndex]}");

            as07_heroHPs[as07_targetIndex] += as07_heal;
            Debug.Log($"TargetHero {as07_targetIndex} hp :{as07_heroHPs[as07_targetIndex]}");
        }

        /*
         * จงเขียนโปรแกรมเพื่อสร้างระบบบทสนทนาที่แสดงข้อความแบบสุ่มจากชุดข้อความที่กำหนดไว้
         * โดยกำหนดให้
         * ตัวแปร:
         * dialogues: เป็น Array ที่เก็บชุดข้อความบทสนทนาทั้งหมด
         * r: เป็นตัวแปรชนิด int ใช้สำหรับเก็บค่าสุ่มเพื่อเลือกข้อความ
         * และแสดงผลข้อความออกมาทางหน้าจอ
         * ตัวอย่าง การใช้ function Random
         * int r = UnityEngine.Random.Range(0, dialogues.Length);
         * สังเกตว่าจะต้องใส่ UnityEngine.Random แทนที่จะใช้ Random ได้เลย เนื่องจากว่าบางครั้งใน code มีการประกาศ using System; และ using UnityEngine; ไว้ทั้งคู่ ซึ่งทั้ง 2 namespace จะมี class Random อยู่ด้วยกันทั้งคู่ ทำให้ compile สับสนว่าจะใช้ Random จาก namespace ใด การระบุไปแบบแน่ชัดเลยว่าเป็น Random จาก UnityEngine โดยใช้ UnityEngine.Random เพื่อหลีกเลี่ยงปัญหานี้
         *
         * ตัวอย่างผลลัพธ์
         *
         * พูดคุยกับ NPC
         *
         * คุณเป็นอย่างไรบ้างครับ
         *
         * พารามิเตอร์:
         * - dialogues: Array ที่เก็บชุดข้อความบทสนทนาทั้งหมด
         */
        [Header("AS08_RandomPickingDialogue")]
        public string[] as08_dialogues;
        public void AS08_RandomPickingDialogue()
        {
            int r = UnityEngine.Random.Range(0, as08_dialogues.Length);
            Debug.Log(as08_dialogues[r]);
        }

        /*
         * จงเขียนโปรแกรมเพื่อสร้างตารางสูตรคูณ จาก 1 - 12
         * โดยให้ผู้ใช้ป้อนจำนวนนั้นเข้ามาในช่อง inputField และแสดงผลลัพธ์ออกมาในรูปแบบของสูตรคูณ เช่น "5x1=5", "5x2=10", ...
         * โดยไล่จาก 1 - 12
         * และ Log ค่าออกมาดังนี้
         * 5x1=5
         * 5x2=10
         * 5x3=15
         * 5x4=20
         * 5x5=25
         * 5x6=30
         * 5x7=35
         * 5x8=40
         * 5x9=45
         * 5x10=50
         *
         * พารามิเตอร์:
         * - n: แม่สูตรคูณที่ต้องการสร้าง (จำนวนเต็มจากช่อง inputField)
         */
        [Header("AS09_MultiplicationTable")]
        public int as09_n;
        public void AS09_MultiplicationTable()
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{as09_n}x{i}={as09_n * i}");
            }
        }

        /*
         * จงเขียนโปรแกรมเพื่อหาผลรวมของจำนวนเต็มตั้งแต่ 1 ถึงจำนวนที่ผู้ใช้ป้อน โดยใช้ while loop
         * กำหนดตัวแปร:
         * sum: ใช้เก็บผลรวมของจำนวนเต็ม
         * i: ใช้เป็นตัวนับในการวนลูป
         * n: เก็บค่าจำนวนเต็มที่ผู้ใช้ป้อนเข้ามา
         * วนลูป:
         * เงื่อนไข: วนลูปจะทำงานต่อไปตราบใดที่ค่าของ i น้อยกว่าหรือเท่ากับ n
         * บวกสะสม: ในแต่ละรอบของลูป ค่าของ i จะถูกบวกเข้าไปใน sum ทำให้ sum เก็บผลรวมของจำนวนเต็มทั้งหมดที่วนลูปมาแล้ว
         * เพิ่มค่าตัวนับ: ค่าของ i จะถูกเพิ่มขึ้น 1 เพื่อเตรียมสำหรับการวนลูปรอบถัดไป
         * เมื่อผู้ใช้ใส่เลข 5
         *
         * ตัวอย่างผลลัพธ์:
         *
         * ผลรวมของ n จาก 1 ถึง 5 คือ 15
         *
         * พารามิเตอร์:
         * - n: จำนวนเต็มที่ผู้ใช้ป้อนเข้ามา
         */
        [Header("AS10_FindSummationFromZeroToNUsingWhileLoop")]
        public int as10_n;
        public void AS10_FindSummationFromZeroToNUsingWhileLoop()
        {
            int sum = 0;
            int i = 0;
            while (i <= as10_n)
            {
                sum += i;
                i++;
            }
            Debug.Log($"ผลรวมของ n จาก 1 ถึง {as10_n} คือ {sum}");
        }

        /*
         * จงเขียนโปรแกรมเพื่อสร้างศัตรูหลายตัวตามจำนวนและตำแหน่งที่กำหนด โดยมีเงื่อนไขดังนี้:
         *
         * สร้างตัวแปร: สร้างตัวแปร Enemy ที่เป็นชนิด GameObject เพื่อเก็บข้อมูลของศัตรูที่จะสร้าง และสร้างตัวแปร HpEnemy ที่เป็นชนิด int[] เพื่อเก็บค่า HP ของศัตรูแต่ละตัว
         * วนลูปสร้างศัตรู:
         * ใช้ for loop เพื่อวนลูปสร้างศัตรูตามจำนวนที่กำหนดในอาร์เรย์ HpEnemy
         * ในแต่ละรอบของลูป ให้สร้างศัตรูหนึ่งตัวโดยใช้ Instantiate โดยกำหนดตำแหน่งของศัตรูให้ห่างจากตำแหน่งปัจจุบันของวัตถุที่ติด script นี้ไปตามแกน X เป็นระยะทางที่เพิ่มขึ้นทีละ 1 หน่วยในแต่ละรอบ
         * กำหนดให้รอบที่ 1 หรือ i == 0 ให้ enemy อยู่ในตำแหน่งที่ x = 1
         * และรอบที่ 2 หรือ i == 1 ให้ enemy อยู่ในตำแหน่งที่ x = 2
         * และรอบที่ 3 หรือ i == 2 ให้ enemy อยู่ในตำแหน่งที่ x = 3
         * ...
         * และรอบที่ n หรือ i == n-1 ให้ enemy อยู่ในตำแหน่งที่ x = n
         * แสดงผล: เมื่อรันโปรแกรม จะต้องเห็นศัตรูหลายตัวถูกสร้างขึ้นมาเรียงกันตามตำแหน่งที่กำหนด
         *
         * พารามิเตอร์:
         * - enemyHPs: อาร์เรย์ของค่า HP ศัตรูแต่ละตัว
         * - enemyPrefab: Prefab ของศัตรูที่จะสร้าง
         */
        [Header("AS11_SpawnEnemies")]
        public int[] as11_enemyHPs;
        public GameObject as11_enemyPrefab;
        public void AS11_SpawnEnemies()
        {
            for (int i = 0; i < as11_enemyHPs.Length; i++)
            {
                GameObject enemy = Instantiate(as11_enemyPrefab, new Vector3(i + 1, 0, 0), transform.rotation);
                Debug.Log("new enemy at x = " + (i + 1));
            }
        }

        /*
         * จงเขียนโปรแกรมเพื่อนับเวลา (Coroutine)
         *
         * พารามิเตอร์:
         * - CountTime: เวลาที่ต้องการนับถอยหลัง / จับเวลา (วินาที)
         */
        [Header("AS12_CountTime")]
        public float as12_countTime;
        public IEnumerator AS12_CountTime()
        {
            float timer = 0f;
            while (timer < as12_countTime)
            {
                timer += Time.deltaTime;
                Debug.Log("DeltaTime: " + timer.ToString("F2"));
                yield return null;
            }
            Debug.Log($"End timer : {as12_countTime}");
        }

        /*
         * ให้นักศึกษาเขียนโปรแกรมเพื่อหาผลรวมของตัวเลขใน Row (แถว)
         *
         * https://cdn-api.elice.io/api-attachment/attachment/8a7f0bbcdbd54117bef5a8742d99496c/image.png
         *
         * โดยกำหนดให้ มีตัวแปรดังนี้
         *
         * public int[,] matrix = {
         *     { 1, 2, 3 },
         *     { 4, 5, 6 },
         *     { 7, 8, 9 } };
         *
         * โดยให้ใช้ for เพื่อหาผลรวมของตัวเลขใน Row ที่ระบุโดยตัวแปร public int row;
         * และเข้าถึงขนาดของ column โดยใช้คำสั่ง matrix.GetLength(1)
         *
         * ตัวอย่างผลลัพธ์:
         *
         * Case 1 - ผลรวมของ Row #0 = 1 + 2 + 3
         * Row ...
         * 0
         * 6
         *
         * Case 2 - ผลรวมของ Row #1 = 4 + 5 + 6
         * Row ...
         * 1
         * 15
         *
         * Case 3 - ผลรวมของ Row #2 = 7 + 8 + 9
         * Row ...
         * 2
         * 24
         *
         * การเข้าถึงขนาดของ 2D Array
         * matrix.GetLength(1): ใช้เพื่อหาจำนวนคอลัมน์ในอาร์เรย์ matrix โดยที่ 1 หมายถึงมิติที่สอง (คอลัมน์)
         * matrix.GetLength(0): ใช้เพื่อหาจำนวนแถวในอาร์เรย์ matrix โดยที่ 0 หมายถึงมิติแรก (แถว)
         *
         * หมายเหตุ: Unity ไม่รองรับการแสดงผล int[,] บน Inspector โดยตรง จึงใช้ class Grid2DInt
         * แทน ซึ่งกรอกค่าเป็นตาราง (grid) ได้จาก Inspector เมื่อจะใช้งานเป็น 2D array จริงๆ ให้เรียก
         * as13_matrix.Get2DArray()
         *
         * พารามิเตอร์:
         * - matrix: 2D array ที่เก็บตัวเลข
         * - row: ดัชนีของแถว (Row) ที่ต้องการหาผลรวม
         */
        [Header("AS13_SumOfNumbersInRow")]
        public Grid2DInt as13_matrix = new Grid2DInt
        {
            rows = 3,
            cols = 3,
            data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        };
        public int as13_row;
        public void AS13_SumOfNumbersInRow()
        {
            int[,] matrix = as13_matrix.Get2DArray();
            int columns = matrix.GetLength(1);
            int sum = 0;
            for (int col = 0; col < columns; col++)
            {
                sum += matrix[as13_row, col];
            }
            Debug.Log(sum);
        }

        /*
         * ให้นักศึกษาเขียนโปรแกรมเพื่อหาผลรวมของคอลัมน์
         *
         * https://cdn-api.elice.io/api-attachment/attachment/1f5f0b4e6ee64c4f8040b43685c8a6f5/image.png
         *
         * โดยกำหนดให้ มีตัวแปรดังนี้
         *
         * public int[,] matrix = {
         *     { 1, 2, 3 },
         *     { 4, 5, 6 },
         *     { 7, 8, 9 } };
         *
         * โดยให้ใช้ for เพื่อรวมผลลัพธ์และเข้าถึงขนาดของแถวโดยใช้คำสั่ง matrix.GetLength(0)
         *
         * ตัวอย่างผลลัพธ์:
         *
         * Case 1: ผลรวมของตัวเลขใน Column #0 = 1 + 4 + 7 = 12
         * Col ...
         * 0
         * 12
         *
         * Case 2: ผลรวมของตัวเลขใน Column #1 = 2 + 5 + 8 = 15
         * Col ...
         * 1
         * 15
         *
         * Case 3: ผลรวมของตัวเลขใน Column #2 = 3 + 6 + 9 = 18
         * Col ...
         * 2
         * 18
         *
         * การเข้าถึงขนาดของ 2D Array
         * myArray.GetLength(1): ใช้เพื่อหาจำนวนคอลัมน์ในอาร์เรย์ myArray โดยที่ 1 หมายถึงมิติที่สอง (คอลัมน์)
         * myArray.GetLength(0): ใช้เพื่อหาจำนวนแถวในอาร์เรย์ myArray โดยที่ 0 หมายถึงมิติแรก (แถว)
         *
         * หมายเหตุ: เช่นเดียวกับ AS13 ตัวแปร matrix ถูกเก็บด้วย class Grid2DInt เพื่อให้แก้ไขค่าได้จาก
         * Inspector เป็นตาราง เมื่อจะใช้งานเป็น 2D array จริงๆ ให้เรียก as14_matrix.Get2DArray()
         *
         * พารามิเตอร์:
         * - matrix: 2D array ที่เก็บตัวเลข
         * - column: ดัชนีของคอลัมน์ (Column) ที่ต้องการหาผลรวม
         */
        [Header("AS14_SumOfNumbersInColumn")]
        public Grid2DInt as14_matrix = new Grid2DInt
        {
            rows = 3,
            cols = 3,
            data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        };
        public int as14_column;
        public void AS14_SumOfNumbersInColumn()
        {
            int[,] matrix = as14_matrix.Get2DArray();
            int rows = matrix.GetLength(0);
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                sum += matrix[row, as14_column];
            }
            Debug.Log(sum);
        }

        /*
         * จงเขียนโปรแกรมใน C# เพื่อแสดงวิธีคิดของการสร้างแผนที่ 3 เหลี่ยม โดยใช้ nested loop
         * โดยมีตัวแปรดังนี้ :
         * int size = 5;
         *
         * ลูปภายนอกควบคุมจำนวนแถว โดยเริ่มที่แถวที่ 1 และสิ้นสุดที่แถวที่ size
         * for (int i = 1; i <= size; i++)
         *
         * ลูปภายในควบคุมจำนวนดาวในแต่ละแถว โดยจำนวนดาวจะเพิ่มขึ้นตามหมายเลขแถว :
         * for (int j = ???????)
         *
         * พิมพ์อักขระ "*" ออกมา แทนการ Instantiate
         * Debug.Log("*");
         *
         * ขึ้นบรรทัดใหม่ แทนการเลื่อนตำแหน่ง Y
         * Console.WriteLine()
         *
         * ตัวอย่างผลลัพธ์:
         *
         * Size ...
         * 5
         * *
         * **
         * ***
         * ****
         * *****
         *
         * Size ...
         * 10
         * *
         * **
         * ***
         * ****
         * *****
         * ******
         * *******
         * ********
         * *********
         * **********
         *
         * พารามิเตอร์:
         * - size: ความสูง / ขนาดของรูปสามเหลี่ยม
         */
        [Header("AS15_MakeTheTriangle")]
        public int as15_size;
        public void AS15_MakeTheTriangle()
        {
            for (int i = 1; i <= as15_size; i++)
            {
                string str = "";
                for (int j = 1; j <= i; j++)
                {
                    str += "*";
                }
                Debug.Log(str);
            }
        }

        /*
         * จงเขียนโปรแกรมภาษา C# เพื่อแสดงตารางสูตรคูณ ตั้งแต่ 2 คูณ 1 ถึง 12 ไปจนถึง 4 คูณ 1 ถึง 12 โดยใช้ Nested Loop
         * ใช้ \t เพื่อเว้นวรรคแท็บระหว่าง column (และในแต่ละบรรทัดจะต้องไม่ลงท้ายด้วย \t) เช่น
         *
         * 2 x 1 = 2\t3 x 1 = 3\t4 x 1 = 4   (สังเกตุว่าจะไม่มี \t ตามท้าย)
         *
         * Debug.Log("\t")
         * หรือ line += "\t";
         *
         * ตัวอย่างผลลัพธ์:
         *
         * 2 x 1 = 2       3 x 1 = 3       4 x 1 = 4
         * 2 x 2 = 4       3 x 2 = 6       4 x 2 = 8
         * 2 x 3 = 6       3 x 3 = 9       4 x 3 = 12
         * 2 x 4 = 8       3 x 4 = 12      4 x 4 = 16
         * 2 x 5 = 10      3 x 5 = 15      4 x 5 = 20
         * 2 x 6 = 12      3 x 6 = 18      4 x 6 = 24
         * 2 x 7 = 14      3 x 7 = 21      4 x 7 = 28
         * 2 x 8 = 16      3 x 8 = 24      4 x 8 = 32
         * 2 x 9 = 18      3 x 9 = 27      4 x 9 = 36
         * 2 x 10 = 20     3 x 10 = 30     4 x 10 = 40
         * 2 x 11 = 22     3 x 11 = 33     4 x 11 = 44
         * 2 x 12 = 24     3 x 12 = 36     4 x 12 = 48
         */
        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            for (int i = 1; i < 13; i++)
            {
                string logStr = "";
                for (int j = 2; j < 5; j++)
                {
                    logStr += $"{j} x {i} = {i * j}";
                    if (j < 4)
                    {
                        logStr += "\t";
                    }
                }
                Debug.Log(logStr);
            }
        }

        #endregion

        #region Extra assignment

        /*
         * จงเขียนโปรแกรมจำลองเกม TicTacToe (XO)
         * กำหนดให้มีตัวแปร board : ขนาด 3x3 เท่านั้น
         * public static string[,] board = new string[3, 3] {
         * {"", "", ""},
         * {"", "", ""},
         * {"", "", ""}
         * };
         *
         * โดย AS11_TicTacToeGame_TurnPlay จะรับ 3 ตัวแปรคือ
         * + player: ระบุว่าในตานี้เป็นของผู้เล่นฝ่ายไหน "X" หรือ "O" X
         * + row, column เป็นการระบุตำแหน่งที่ผู้เล่นตานี้เลือกจะลงใน board เช่น row=0, column=1
         * โดยที่ method นี้จะต้องพิมพ์ ตารางหลังจากใส่ค่าออกมา
         * และแสดงว่าผลลัพธ์การเล่นตานั้นเกิดอะไรขึ้น ซึ่งจะมีความเป็นไปได้ทั้งหมด 5 รูปแบบคือ
         * -> ">> X Win!" เมื่อ player "X" ลงตานี้แล้วขนะ
         * -> ">> O Win!" เมื่อ player "O" ลงตานี้แล้วขนะ
         * -> ">> Draw" เมื่อผู้เล่น X หรือ O ลงไปแล้วไม่มีผู้ชนะ
         * -> ">> Continue" เมื่อผู้เล่น X หรือ O ลงไปแล้วเกมยังไม่จบ - ไม่มีผู้ชนะ และยังเหลือช่องว่างให้ผู้เล่นอีกคนลงต่อได้
         * -> ">> Invalid move" เมื่อผู้เล่น X หรือ O เลือกลงไปในช่องที่ไม่ว่าง หรือไม่มีอยู่จริงเข่น row=1000 column=1999
         *
         * Input
         * board:
         * -------------
         * |   | X |   |
         * -------------
         * |   |   |   |
         * -------------
         * |   |   |   |
         * -------------
         * player: "X"
         * row: 0
         * column: 1
         *
         * Output
         * -------------
         * |   | X |   |
         * -------------
         * |   |   |   |
         * -------------
         * |   |   |   |
         * -------------
         * >> Continue
         *
         * Input
         * board:
         * -------------
         * |   | X |   |
         * -------------
         * |   |   |   |
         * -------------
         * |   |   |   |
         * -------------
         * Player: "O"
         * row: 1
         * col: 1
         *
         * Output:
         * -------------
         * |   | X |   |
         * -------------
         * |   | O |   |
         * -------------
         * |   |   |   |
         * -------------
         * >> Continue
         *
         * NOTE การพิมพ์ตารางให้ระวังเรื่อง space ให้ดี
         *
         * โดยหากช่องนั้นไม่ว่างให้ (Invalid input) ให้พิมพ์ออกมาว่าไม่สามารถลงในตำแหน่งที่ต้องการได้ cannot set X at 0 2 และวนกลับไปให้เซตค่าใหม่
         *
         * Input
         * board:
         * -------------
         * | X |   | O |
         * -------------
         * |   |   |   |
         * -------------
         * |   |   |   |
         * -------------
         * Player: O
         * row: 0
         * column: 2
         *
         * Output
         * -------------
         * | X |   | O |
         * -------------
         * |   |   |   |
         * -------------
         * |   |   |   |
         * -------------
         * >> Invalid move
         *
         * หลังจากการลงในแต่ละตา ระบบเกมจะต้อง check ว่า ใครเป็นฝ่ายชนะ เช่น
         *
         * Input
         * board:
         * -------------
         * | X | X |   |
         * -------------
         * | X | O |   |
         * -------------
         * | O |   |   |
         * -------------
         * player: O
         * row: 2
         * column: 0
         *
         * Output
         * -------------
         * | X | X | O |
         * -------------
         * | X | O |   |
         * -------------
         * | O |   |   |
         * -------------
         * >> O wins!
         *
         * Input
         * board:
         * -------------
         * | X |   | O |
         * -------------
         * |   |   | O |
         * -------------
         * |   |   | X |
         * -------------
         * Player: X
         * row: 2
         * column: 2
         *
         * Output
         * -------------
         * | X |   | O |
         * -------------
         * |   | X | O |
         * -------------
         * |   |   | X |
         * -------------
         * >> X wins!
         *
         * และถ้าลงจนครบทุกช่องแล้วไม่มีผู้ชนะ ให้พิมพ์ว่า Draw!
         *
         * Input
         * board:
         * -------------
         * | X | X | O |
         * -------------
         * | O | O | X |
         * -------------
         * | X |   | X |
         * -------------
         * Player: O
         * row: 2
         * column: 1
         *
         * Output
         * -------------
         * | X | X | O |
         * -------------
         * | O | O | X |
         * -------------
         * | X | O | X |
         * -------------
         * >> Draw
         *
         * Input
         * board:
         * -------------
         * | X | X | O |
         * -------------
         * | O | O | X |
         * -------------
         * | X | O |   |
         * -------------
         * Player: X
         * row: 2
         * column: 2
         *
         * Output
         * -------------
         * | X | X | O |
         * -------------
         * | O | O | X |
         * -------------
         * | X | O | X |
         * -------------
         * >> Draw
         *
         * หมายเหตุ: Unity ไม่รองรับการแสดงผล string[,] บน Inspector โดยตรง จึงใช้ class Grid2DString
         * แทน ซึ่งกรอกค่าเป็นตาราง (grid) ได้จาก Inspector เมื่อจะใช้งานเป็น 2D array จริงๆ ให้เรียก
         * ex01_board.Get2DArray()
         *
         * พารามิเตอร์:
         * - board: กระดาน Tic Tac Toe ขนาด 3x3
         * - playerTurn: ตาของผู้เล่น "X" หรือ "O"
         * - row: แถวที่ต้องการเล่น (index 0 - 2)
         * - column: คอลัมน์ที่ต้องการเล่น (index 0 - 2)
         */
        [Header("EX_01_TicTacToeGame_TurnPlay")]
        public Grid2DString ex01_board = new Grid2DString
        {
            rows = 3,
            cols = 3,
            data = new string[] {
                "X", "X", "O",
                "X", "O", "X",
                "", "", ""
            }
        };
        public string ex01_playerTurn = "O";//กรอกเป็น X พิมพ์ใหญ่หรือ O พิมพ์ใหญ่เท่านั้น
        public int ex01_row = 2;
        public int ex01_column = 0;
        public void EX_01_TicTacToeGame_TurnPlay()
        {
            var board = ex01_board.Get2DArray();
            throw new NotImplementedException();
        }
        #endregion

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + spaceIfEmpty(board[i, 0]) + " | " + spaceIfEmpty(board[i, 1]) + " | " + spaceIfEmpty(board[i, 2]) + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }

        private string spaceIfEmpty(string value)
        {
            return string.IsNullOrEmpty(value) ? " " : value;
        }
    }

}
