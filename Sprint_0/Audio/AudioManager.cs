using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Sprint_0.GameStates;
using Sprint_0.HUD;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

public class AudioManager
{
    public Song song;
    public List<SoundEffect> soundEffects;

    public AudioManager(ContentManager c)
    {
        Content.RootDirectory = "Content";
        soundEffects = new List<SoundEffect>();
        song = Content.Load<Song>("suge");
        playSong();
    }

    public void populateSoundEffects()
    {
    //    soundEffects.Add();
    }

    public void playSong()
    {
        MediaPlayer.Play(song);
    }



    public void volumeDown()
    {
        MediaPlayer.Volume -= 0.1f;
    }

    public void volumeUp()
    {
        MediaPLayer.Volume += 0.1f;
    }
}