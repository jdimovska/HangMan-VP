**Hangman (Бесилка)**
-----------------

***Членови на тимот:***

 - Марина Ангеловска   141061	
 - Јона Димовска       141039
 - Филип Станојковски  141522

**1. Опис на апликацијата**

Играта која што ние ја направивме е бесилка. Ја проширивме основната идеја на играта со тоа што додадовме неколку дополнителни функционалности со цел да биде покомплексна и повеќе прилагодлива на играчот . 
Во зависнот од должината на зборот(која играчот сам ја одбира) се гради и неговиот High Score, а исто така воведовме и Hint копче  со кое што се открива една рандом буква од зборот. Во текот на целата игра има soundtrack со можност да се исклучи преку клик на сликичкта која се наоѓа на десниот агол на Home-page.

![HomePage](https://github.com/jdimovska/HangMan-VP/blob/master/Printscreens/1.png)
 

**2. Упатство за играње**

Со стартување на играта се отвара Home Screen во кој има избор од три можности:

1)	Со кликање на копчето **Play** се отвара нов прозорец во кој играчот треба да одбере една од трите можни категории: Финки, Животни или Главни градови. По избирањето на категоријата се отвора нова форма во која што се игра играта. На почетокот играчот треба да ја одбере должината на зборот која што може да биде од 5-9 букви и да кликне на копчето Start. Со тоа играта започнува и се појавува тајмер кој што е различен за секој збор со различна должина соодветно. Играчот има време да ја заврши играта додека тајмерот не стигне до 0. Доколку играчот сака помош, со кликање на копчето Hint ќе се генерира една рандом буква во зборот и ова е можно само еднаш во текот на една игра. Максималниот број на згрешени букви е 6, односно со одбирање на 6 погрешни букви се појавува нов прозорец Game Over на кој се прикажува точниот збор и  тука исто така играчот има можност да се врати на почетната страна или пак да излезе од играта. Доколку играчот го погоди зборот се отвара прозорец за запишување на неговото име и high score. Доколку играчот не впише ништо во полето за име, се внесува неговиот high score под име Unknown. Во случај да не се заврши играта, а играчот сака да излезе се притиска на копчето End и се отвара дијалог прозорец за потврда на оваа акција. Играта може во секој момент да се исклучи преку close копчето на секоја форма.


 ![Play](https://github.com/jdimovska/HangMan-VP/blob/master/Printscreens/2.png)
 
2)	Со одбирање на **Help** се отвара краток опис за правилата на игра. А со кликање на логото на играта или на стрелката се овозможува враќање назад кон Home page.

3)	 Во делот за **High Scores** се сортирани најдобрите 5 играчи заедно со нивните поени. Поените ги пресметувавме според формулата score= 10*погодена_буква*преостанато_време. А со барање на Hint се одзимаат -10 поени. Копчето "Clear" ги брише сите "High Scores".

 ![HighScores](https://github.com/jdimovska/HangMan-VP/blob/master/Printscreens/3.png)
 

**3. Опис на решението**

Целата база од зборови ја чуваме во три енкриптирани датотеки (поделени според категоријата) со цел корисникот да не може да ја отвори и разгледува базата. При секоја игра и избор на должината на зборот се генерира рандом број и се зима зборот со тој реден број од соодветната категорија на зборови со таа должина. Со Hint копчето секогаш се дава првата непогодена буква од зборот и е дозволено само една употреба при една игра. Со погодување на буква се испишува наместо одредена долна црта на кое место таа буква се наоѓа, а со грешење на буква се генерира соодветна слика(секоја слика содржи еден дел од човечето повеќе).  

```c#
private void vpisiBukva(char c)
        {
            bool flag = false;
            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
                c = Char.ToLower(c);
                if (c == orginal[i])
                {
                    crticki[i] = c;
                    trueLetters++;
                    scorePlayer += 10;
                    flag = true;

                }

                if (trueLetters == (int)numericUpDown1.Value) {

                    HighScore score = new HighScore(scorePlayer*timeLeft);
                    timer1.Stop();
                    score.Show();
                    
                    this.Hide();

                    break;
                }

            }
            if (!flag)
                falseLetters++;
```

Со впишување на High Score всушност се впишуваат поени и корисникот во одредена датотека за која што исто така е користена енкрипција и заштита. Постојано се сортираат најдобрите 5 играчи и нивните поени се прикажуваат.

*(Фичо print screen од класата за high score и енкрипицја и објаснување)* 
```c#
 public partial class HighScore : Form
    {
        List<Tuple<String, int>> hs = new List<Tuple<string, int>>();
        public int score;
        public HighScore(int score)
        {
            this.score = score;
            InitializeComponent();
            textBox2.Text = Convert.ToString(score);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string outp = @"../../Resources/scorencr.txt";
            string decr = @"../../Resources/scoredecr.txt";
            encDecr en = new encDecr();
            if (!File.Exists(outp))
            {
                File.Create(decr).Close();
                StreamWriter wr = new StreamWriter(decr, true);
                wr.WriteLine(textBox1.Text + ' ' + textBox2.Text);
                wr.Flush();
                wr.Close();
                en.EncryptFile(decr, outp);
                File.Delete(decr);
            }
            else
            {
                en.DecryptFile(outp, decr);
                File.Delete(outp);
                
                hs.Add(new Tuple<String,int>(textBox1.Text, int.Parse(textBox2.Text)));
                StreamReader read = new StreamReader(decr);
                String line;
                while((line=read.ReadLine())!=null)
                {
                    var d = line.Split(' ');
                    String name = d[0];
                    int scr = int.Parse(d[1]);
                    hs.Add(new Tuple<String, int>(name, scr));
                }
                read.Close();
                hs.Sort((x, y) => y.Item2.CompareTo(x.Item2));
                File.Delete(decr);
                File.Create(decr).Close();
                StreamWriter wr = new StreamWriter(decr, true);
                for (int j=0;j<hs.Count;j++)
                {
                    wr.WriteLine(hs[j].Item1 + ' ' + hs[j].Item2);
                }
                wr.Flush();
                wr.Close();
                en.EncryptFile(decr, outp);
                File.Delete(decr);
            }
            this.Hide();
            Form1 home = new Form1();
            int i = 1;
            home.res(i);
           
            
        }
```
За да ги запишеме најдобрите резултати, користиме листа од туплес така што секое тупле има два предмети каде првиот е од типот "String", а вториот е од типот "int".
```c#
List<Tuple<String, int>> hs = new List<Tuple<string, int>>();
```
Кога внесуваме нов "High Score", 

![EnterHighScore](https://github.com/jdimovska/HangMan-VP/blob/master/Printscreens/5.png)
доколку не постојат претходни "High Scores", се креира нов текст документ во кој се запишува резултатот во формат "Име Резултат" и потоа се енкриптира.
```c#
if (!File.Exists(outp))
{
    File.Create(decr).Close();
    StreamWriter wr = new StreamWriter(decr, true);
    wr.WriteLine(textBox1.Text + ' ' + textBox2.Text);
    wr.Flush();
    wr.Close();
    en.EncryptFile(decr, outp);
    File.Delete(decr);
}
```
Во спротива во листата се додава новиот резултат, се декриптира веќе постоечкиот документ со резултати и еден по еден ги додаваме во листата. Потоа го бришеме документот со резултати.
```c#
en.DecryptFile(outp, decr);
File.Delete(outp);
hs.Add(new Tuple<String,int>(textBox1.Text, int.Parse(textBox2.Text)));
StreamReader read = new StreamReader(decr);
String line;
while((line=read.ReadLine())!=null)
{
    var d = line.Split(' ');
    String name = d[0];
    int scr = int.Parse(d[1]);
    hs.Add(new Tuple<String, int>(name, scr));
}
```
Резултатите се сортираат со "LINQ" по опаѓачки редослед,
```c#
hs.Sort((x, y) => y.Item2.CompareTo(x.Item2));
```
креираме нов празен документ во кој еден по еден ги запишуваме сортираните резултати и на крај го енкриптираме документот.
```c#
File.Create(decr).Close();
StreamWriter wr = new StreamWriter(decr, true);
for (int j=0;j<hs.Count;j++)
{
    wr.WriteLine(hs[j].Item1 + ' ' + hs[j].Item2);
}
wr.Flush();
wr.Close();
en.EncryptFile(decr, outp);
File.Delete(decr);
```
