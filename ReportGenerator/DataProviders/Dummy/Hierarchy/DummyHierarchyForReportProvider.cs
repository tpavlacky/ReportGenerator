using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace ReportGenerator.DataProviders.Dummy.Hierarchy
{
	public class DummyHierarchyForReportProvider : ITestPlanForReportProvider
	{
		private Random _random = new Random();

		public IList<IReportItem> GetData(uint testSuiteID, CancellationToken cancellationToken, IProgress<string> progress)
		{
			return new List<IReportItem>{new TestPlan(0, 0, "Regression dummy test plan", GetRandomTestSummary(), null, string.Empty, null, new List<IReportItem>
			{
				CreateTestSuite(1, 0,
					new List<IReportItem>
					{
						//CreateTestCase(14, 0),
						CreateTestSuite(11, 1, new List<IReportItem>
						{
							CreateTestCase(111, 11),
							CreateTestCase(112, 11),
							CreateTestCase(113, 11),
						}),
						CreateTestCase(12, 0),
						CreateTestCase(13, 0),
						CreateTestCase(14, 0),
						CreateTestCase(15, 0),
						CreateTestCase(16, 0),
						CreateTestCase(17, 0),
						CreateTestCase(18, 0),
						CreateTestCase(19, 0),
						CreateTestCase(20, 0),
					}),
				CreateTestSuite(2, 0, new List<IReportItem>
				{
					CreateTestSuite(21, 2, new List<IReportItem>()
					{
						CreateTestCase(211, 21),
						CreateTestCase(212, 21)
					}),
					CreateTestSuite(22, 2, new List<IReportItem>
					{
						CreateTestCase(221, 22)
					})
				}),
				CreateTestSuite(3, 0, new List<IReportItem>
				{
					CreateTestSuite(31, 3),
					CreateTestSuite(32, 3),
					CreateTestSuite(33, 3, new List<IReportItem>
					{
						CreateTestCase(331, 33)
					}),
				}),
				CreateTestSuite(4, 0, new List<IReportItem>
				{
					CreateTestSuite(41, 4),
					CreateTestSuite(42, 4),
					CreateTestSuite(43, 4, new List<IReportItem>
					{
						CreateTestCase(431, 43)
					}),
				})}, new Uri("http://www.google.com"))};
		}



		private TestSuite CreateTestSuite(int id, int parentID)
		{
			return CreateTestSuite(id, parentID, new List<IReportItem>(0));
		}

		private TestSuite CreateTestSuite(int id, int parentID, IList<IReportItem> items)
		{
			return new TestSuite(id, parentID, $"Dummy test suite {id}", GetRandomTestSummary(), null, string.Empty, null, items, new Uri("http://www.seznam.cz"));
		}

		//private void AddTestCase(TestSuite testSuite, int testCaseID)
		//{
		//	testSuite.Children.Add(CreateTestCase(testCaseID, testSuite.ID));
		//}

		private TestCase CreateTestCase(int id, int parentID)
		{
			return new TestCase(id, parentID, $"Caption for TC {id}", GetRandomTestSummary(), GetRandomTestOutcome(), "Tested by someone", DateTime.Now, new List<IReportItem>(0), new Uri("http://www.idnes.cz"), "Win 10-64 bit", TimeSpan.FromSeconds(_random.Next(0, 50)
));
		}

		private TestOutcome GetRandomTestOutcome()
		{
			var value = _random.Next(2, 4);
			return (TestOutcome)value;
		}

		private string GetRandomTestSummary()
		{
			var summaryIndex = _random.Next(0, 10);
			return _randomTestSummaries[summaryIndex];
		}

		private readonly string[] _randomTestSummaries = new string[]
		{
			@"Klein in denen unter er sahen um. Ochsen storen kam gru mag sto bitter. Ehe mag eberhard kurioses spateren nirgends. Eigenes standen bestand pa in da konntet ab meisten kapelle. Weile nun und sunde augen. Laut da rief zu ei es also. Unsicherer hinstellte la ja kuchenture. Gut grasplatz hut herkommen ertastete vogelnest handwerke.",
			@"Viehmarkt er unendlich mitkommen kellnerin gegriffen wu. Bei hin stopfen regnete nachdem alsbald zwiebel schlank gru. Aufstehen vermodert schneider nebendran dammerung sto flu. Solle diese trost am wo riefe em. Zur ten ruh lass paar und dort sein lauf scho. Statt flo sogar bat als lauft einen. Man nah kind las mann ware also ist. Um sorglosen kindliche liebevoll gestorben es je. ",
			@"So leer ware doch rote scho la. Im lehrlingen feierabend er ja ja bugeleisen gesprachig. En gang so he frau mude es. Zueinander federdecke wasserkrug er he. Leid hort nein ein mir kaum ins. Sohlen fu mu kehrte wo en sitzen. Ortes wurde extra stuhl im du schau es zu. Richtete sparlich du erzahlen konntest gesichts ri burschen. Kraftlos ob lampchen so er te schreien zinnerne vorwarts schweren. ",
			@"Liebhaben vergesset dammerung gepfiffen furchtete tag ans neu wer. Dus tor madchen atemzug ich namlich nur meister. Unruhig sah kleinen heruber ist abwarts kindern scheint zur mit. Wesen holen naher warum ist sagen lauft flu. Keiner ei spahte schade gefegt bundel gefiel ri. Verwegene vor schreibet geblieben geheimnis leuchtete lie unwissend. Schlank alsbald schwach um diesmal je instand manchen. ",
			@"Schuchtern leuchtturm neidgefuhl la se dienstmagd im flusterton erkundigte. Fragen beeten werdet ordnen wochen oha loffel tod gar zur. Knabenhaft arbeitsame verdrossen mi sauberlich hinstellte flusterton he. Immer halbe blo pfiff stirn tal nadel wenns. Schlecht blaulich horchend zu erkannte du marschen. Schuttelte so er brotkugeln hereintrat. Auskleiden alt aufgespart abendsuppe vor. ",
			@"Stuckchen nichtstun lieblinge ausblasen te em in spazieren. Alt ein leuchtturm lehrlingen eigentlich mir knabenhaft hut. Herrn junge jahre wovon bei ist unten. Sto hinuber und preisen brachte. Wei see knarre lehren denken. Herrje gehabt wir nimmer bei. Art bescheiden sie bodenlosen flusterton betrachtet wei. Loben damit keins ku wette trost ri se da. Bei tut hin essen jetzt stube wer. Wie luke ehe bist hort. ",
			@"Erst vorn wie des halt weil gro dus. Ja brauerei gelaufig zu jahrlich an gerberei du erzahlen konntest. Eisen sechs setzt um so denen gehen wills. Nadel was hat euern weich. Er gedanken du da zwischen bezahlen gegangen wohlfeil. Boden angst holen fu da. Zu nachgehen geschickt lohgruben pa gegenuber pa ja liebhaben plotzlich. Er es ruhen sechs ei blick flick es. ",
			@"In es dieses schale ku du konnte besann kleine drehte. Frohlich tag flo brotlose menschen kindbett abraumen bezahlen. Du lief wahr he tale heut hell so herd. Getafel sa fremden stillen unruhig am geruckt es ei. Gern duse vers fast ihr wir auch sehe. Nur besonderes getunchten grashalden bugeleisen ten. Gebeugt erstieg kriegen em zweimal en. Viel ja froh gibt aber da habs an la. ",
			@"Schlecht mu la neunzehn lauschte ab. Schien keinem drehte teller sah eia hin minute. Man wei ins heruber leuchte dus hochmut. Flusterton du unsicherer da ab ungerechte ob wasserkrug. Gewesen fischen bi im wachter in gewerbe. Fu vorpfeifen sa wu halboffene sonderling. ",
			@"Ab augenblick freundlich dazwischen he da in aufmerksam ordentlich. Zehn die tage wie ten frau sehe dies. Tief sind ri in zehn berg. Gelandes arbeiter im brotlose allerlei ab wirklich horchend so ri. Stickig ja schlief pa spiegel geschah es melodie. Offenen geruckt madchen braunen hol glatten auf mir. Dachkammer pa aneinander da ungerechte ja nachmittag achthausen kuchenture. Las daran genie ort das komme zwirn der blies. Dies auch dank ein gern das eile land. Nur dazwischen kindlichen see lehrlingen. ",
		};
	}
}
