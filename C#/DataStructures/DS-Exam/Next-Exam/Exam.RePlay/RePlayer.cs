using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.RePlay
{
    public class RePlayer : IRePlayer
    {

        private Dictionary<string, List<Track>> albums;
        private List<Track> tracks;
        private Queue<Track> listeningQueue;

        public RePlayer()
        {
            albums = new Dictionary<string, List<Track>>();
            tracks = new List<Track>();
            listeningQueue = new Queue<Track>();
        }

        public int Count => tracks.Count;

        public void AddToQueue(string trackName, string albumName)
        {
            CheckForAlbumAndTrack(trackName, albumName);

            var songToQueue = albums[albumName].First(t => t.Title == trackName);
            listeningQueue.Enqueue(songToQueue);
        }

        public void AddTrack(Track track, string album)
        {
            if (!albums.ContainsKey(album))
            {
                albums[album] = new List<Track>();
            }

            track.AlbumName = album;
            albums[album].Add(track);
            tracks.Add(track);
        }

        public bool Contains(Track track)
        {
            return tracks.Contains(track);
        }

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            if (!albums.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            return albums[albumName].OrderByDescending(t => t.Plays);
        }

        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            var isSuchArtist = tracks.FirstOrDefault(t => t.Artist == artistName);

            if (isSuchArtist == null)
            {
                throw new ArgumentException();
            }

            var discography = new Dictionary<string, List<Track>>();

            foreach (var songs in albums)
            {
                if (songs.Value.FirstOrDefault(t => t.Artist == artistName) != null)
                {
                    discography.Add(songs.Key, songs.Value);
                }
            }

            return discography;
        }

        public Track GetTrack(string title, string albumName)
        {
            CheckForAlbumAndTrack(title, albumName);

            return albums[albumName].First(t => t.Title == title);
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        {
            var all = new List<Track>(tracks);

            return all.Where(t => t.DurationInSeconds >= lowerBound && t.DurationInSeconds <= upperBound)
                .OrderBy(t => t.DurationInSeconds)
                .ThenByDescending(t => t.Plays);
        }

        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
        {
            return tracks.OrderBy(t => t.AlbumName).ThenByDescending(t => t.Plays).ThenByDescending(t => t.DurationInSeconds);
        }

        public Track Play()
        {
            if (listeningQueue.Count == 0)
            {
                throw new ArgumentException();
            }

            var songToRemove = listeningQueue.Dequeue();

            tracks.FirstOrDefault(s => s == songToRemove).Plays++;

            return songToRemove;
        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
            CheckForAlbumAndTrack(trackTitle, albumName);

            var songToRemove = albums[albumName].First(t => t.Title == trackTitle);

            albums[albumName].Remove(songToRemove);
            tracks.Remove(songToRemove);

            var updatedListeningQueue = new Queue<Track>();

            foreach (var song in listeningQueue)
            {
                if (song != songToRemove) // possible mistake
                {
                    updatedListeningQueue.Enqueue(song);
                }
            }

            listeningQueue = updatedListeningQueue;
        }

        private void CheckForAlbumAndTrack(string title, string albumName)
        {
            if (!albums.ContainsKey(albumName) || albums[albumName].FirstOrDefault(t => t.Title == title) == null)
            {
                throw new ArgumentException();
            }
        }
    }
}
