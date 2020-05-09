class Scene1 extends Phaser.Scene {
    constructor() {
        super("bootGame"); //bootGame = identifier for this particular scene
    }

    //function to load up all of the necessary objects
    preload() {
        //load the background image
        this.load.image("background", "assets/images/background.png");

        //load all of the spritesheets
        this.load.spritesheet("ship", "assets/spritesheets/ship.png", {
            frameWidth: 16,
            frameHeight: 16
        });

        this.load.spritesheet("ship2", "assets/spritesheets/ship2.png", {
            frameWidth: 32,
            frameHeight: 16
        });

        this.load.spritesheet("ship3", "assets/spritesheets/ship3.png", {
            frameWidth: 32,
            frameHeight: 32
        });

        this.load.spritesheet("explosion", "assets/spritesheets/explosion.png", {
            frameWidth: 16,
            frameHeight: 16
        });

        this.load.spritesheet("power-up", "assets/spritesheets/power-up.png", {
            frameWidth: 16,
            frameHeight: 16
        });

        this.load.spritesheet("player", "assets/spritesheets/player.png", {
            frameWidth: 16,
            frameHeight: 24
        });

        this.load.spritesheet("beam", "assets/spritesheets/beam.png", {
            frameWidth: 16,
            frameHeight: 16
        });

        //load the font that's being used
        this.load.bitmapFont("pixelFont", "assets/font/font.png", "assets/font/font.xml");

        //load up the audio files to use
        this.load.audio("audio_beam", ["assets/sounds/beam.ogg", "assets/sounds/beam.mp3"]);
        this.load.audio("audio_explosion", ["assets/sounds/explosion.ogg", "assets/sounds/explosion.mp3"]);
        this.load.audio("audio_pickup", ["assets/sounds/pickup.ogg", "assets/sounds/pickup.mp3"]);
        this.load.audio("music", ["assets/sounds/sci-fi_platformer12.ogg", "assets/sounds/sci-fi_platformer12.mp3"]);

    }

    //function to create all of the necessary objects
    create() {
        this.add.text(20, 20, "Loading game..."); //creates the text which will be displayed on the screen
        this.scene.start("playGame");

        //create the animationss
        this.anims.create({
            key: "red",
            frames: this.anims.generateFrameNumbers("power-up", {
                start: 0,
                end: 1
            }),
            frameRate: 20,
            repeat: -1
        });
        this.anims.create({
            key: "gray",
            frames: this.anims.generateFrameNumbers("power-up", {
                start: 2,
                end: 3
            }),
            frameRate: 20,
            repeat: -1
        });

         //create the animation
         this.anims.create({
            key: "ship1_anim", //name of animation
            frames: this.anims.generateFrameNumbers("ship"), //using the spritesheet
            frameRate: 20, //how many frames per second
            repeat: -1 //this indicates how many times it will loop
        });

        this.anims.create({
            key: "ship2_anim", //name of animation
            frames: this.anims.generateFrameNumbers("ship2"), //using the spritesheet
            frameRate: 20, //how many frames per second
            repeat: -1 //this indicates how many times it will loop
        });

        this.anims.create({
            key: "ship3_anim", //name of animation
            frames: this.anims.generateFrameNumbers("ship3"), //using the spritesheet
            frameRate: 20, //how many frames per second
            repeat: -1 //this indicates how many times it will loop
        });

        this.anims.create({
            key: "explode", //name of animation
            frames: this.anims.generateFrameNumbers("explosion"), //using the spritesheet
            frameRate: 20, //how many frames per second
            repeat: 0, //this indicates how many times it will loop
            hideOnComplete: true //because the explosion indicates the end of the game, this will be true
        });

        this.anims.create({
            key: "thrust",
            frames: this.anims.generateFrameNumbers("player"),
            frameRate: 20,
            repeat: -1
        })

        this.anims.create({
            key: "beam_anim",
            frames: this.anims.generateFrameNumbers("beam"),
            frameRate: 20,
            repeat: -1
        });
    }
}