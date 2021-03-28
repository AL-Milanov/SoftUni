// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		private const string FirstName = "Ivan";
		private const string LastName = "Ivanov";
		private const int LegitAge = 18;
		private const string SongName = "TNT";
		private Stage stage;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
        }

		[Test]
	    public void When_AddPerformerWithAgeLessThanEightteen_ShouldThrowArgumentException()
	    {
			Performer performer = new Performer(FirstName, LastName, 17);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
		}

		[Test]
		public void When_AddPerformerWithPerformerThatIsNull_ShouldThrowArgumentNullException()
        {
			Performer performer = null;
			Assert.Throws<ArgumentNullException>(() => { stage.AddPerformer(performer); });
        }

		[Test]
		[TestCase(FirstName, LastName, LegitAge)]
		[TestCase(FirstName, LastName, LegitAge * 2)]
		public void When_AddPerformerWithCorrectData_ShouldAddPerformerToList(string firstName, string lastName, int age)
        {
			Performer performer = new Performer(firstName, lastName, age);
			stage.AddPerformer(performer);
			Assert.That(string.Join(Environment.NewLine, stage.Performers), Is.EqualTo(performer.ToString()));
        }

		[Test]
		public void When_AddPSongWithSongThatIsNull_ShouldThrowArgumentNullException()
		{
			Song song = null;
			Assert.Throws<ArgumentNullException>(() => { stage.AddSong(song); });
		}

		[Test]
		public void When_AddPSongWithSongThatIsLessThanOrOneMinute_ShouldThrowArgumentException()
		{
			TimeSpan duration = new TimeSpan(00, 00, 59);

			Song firstSong = new Song(SongName, duration);

			Assert.Throws<ArgumentException>(() => { stage.AddSong(firstSong); });
		}

		[Test]
		public void When_AddSongToPerformerThatPerformerIsNotPresented_ShouldThrowArgumentException()
        {
			Performer performer = new Performer(FirstName, LastName, LegitAge * 2);
			Song song = new Song(SongName, new TimeSpan(00, 05, 23));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => { 
				stage.AddSongToPerformer(SongName, "Invalid Name"); });
        }

		[Test]
		public void When_AddSongToPerformerThatSongIsNotPresented_ShouldThrowArgumentException()
		{
			Performer performer = new Performer(FirstName, LastName, LegitAge * 2);
			Song song = new Song(SongName, new TimeSpan(00, 05, 23));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => {
				stage.AddSongToPerformer("Invalid Song", performer.FullName);
			});
		}

		[Test]
		public void When_AddSongToPerformerWithCorrectData_ShouldAddSongToPerformer()
		{
			Performer performer = new Performer(FirstName, LastName, LegitAge * 2);
			Song song = new Song(SongName, new TimeSpan(00, 05, 23));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			stage.AddSongToPerformer(SongName, performer.FullName);

			Assert.That(performer.SongList.Contains(song));
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		public void When_Play_ShouldReturnStringWithPerformersCountAndSongListCount(int count )
        {
            for (int i = 0; i < count; i++)
            {
				Performer performer = new Performer(FirstName, LastName, LegitAge + i);

				Song song = new Song(SongName, new TimeSpan(00, 05, 00));

				stage.AddPerformer(performer);
				stage.AddSong(song);

				stage.AddSongToPerformer(SongName, performer.FullName);
            }
			string expectedMessage = $"{count} performers played {count} songs";

			Assert.That(stage.Play(), Is.EqualTo(expectedMessage));
        }
	}
}