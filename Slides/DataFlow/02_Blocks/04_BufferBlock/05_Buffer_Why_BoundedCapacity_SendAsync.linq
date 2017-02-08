<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

//techniczny kod
var colorFormat= @"<span style='color:Blue;'>{0}</span>";

//tworzymy bufor z limitem na 2 wiadomości
var bb = new BufferBlock<int>(new DataflowBlockOptions() { BoundedCapacity = 2 });

//tworzymy blok wypisujące i czekające
var a1 = new ActionBlock<int>(
a => {
		Console.WriteLine("Action A1 executing with value {0}", a);
      	Thread.Sleep(1000);
     }
    ,new ExecutionDataflowBlockOptions(){ BoundedCapacity = 1 } //ograniczamy ilość wiadomości w bloku
);

var a2 = new ActionBlock<int>(
a => {
        Console.WriteLine("Action A2 executing with value {0}", a);
		Thread.Sleep(500);
     }
     ,new ExecutionDataflowBlockOptions(){ BoundedCapacity = 1} //ograniczamy ilość wiadomości w bloku
);
var a3 = new ActionBlock<int>( 
a => {
		Console.WriteLine("Action A3 executing with value {0}", a);
	    Thread.Sleep(500);
	 }
	,new ExecutionDataflowBlockOptions(){ BoundedCapacity = 1} //ograniczamy ilość wiadomości w bloku
);
bb.LinkTo(a1);
bb.LinkTo(a2);
bb.LinkTo(a3);

for(int i=0; i<10 ;i++)
{
	var iCopy=i;
	bb
		.SendAsync(i)
		.ContinueWith(a => Console.WriteLine(Util.RawHtml(string.Format(colorFormat,string.Format("Wiadomość {0} przyjęta? {1}",iCopy,a.Result)))));
}