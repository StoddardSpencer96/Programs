class Scene2 extends Phaser.Scene {
    constructor() {
        super("playGame"); //playGame = identifier for this particular scene
    }

    //function to create all of the necessary objects
    create() {
        //add the following to the game
        //this.background = this.add.image(0, 0, "background"); //create the image
        this.background = this.add.tileSprite(0, 0, config.width, config.height, "background");
        this.background.setOrigin(0, 0); //determine where the image will load

    
        // this.ship1 = this.add.image(config.width / 2 - 50, config.height / 2, "ship");
        // this.ship2 = this.add.image(config.width / 2, config.height / 2, "ship2");
        // this.ship3 = this.add.image(config.width / 2 + 50, config.height / 2, "ship3");

        this.ship1 = this.add.sprite(config.width / 2 - 50, config.height / 2, "ship");
        this.ship2 = this.add.sprite(config.width / 2, config.height / 2, "ship2");
        this.ship3 = this.add.sprite(config.width / 2 + 50, config.height / 2, "ship3");

        //put all of our ships into a group
        this.enemies = this.physics.add.group();
        this.enemies.add(this.ship1);
        this.enemies.add(this.ship2);
        this.enemies.add(this.ship3);

        this.ship1.play("ship1_anim");
        this.ship2.play("ship2_anim");
        this.ship3.play("ship3_anim");

        //make each ship interactive
        this.ship1.setInteractive();
        this.ship2.setInteractive();
        this.ship3.setInteractive();

        //add an event listener
        this.input.on('gameobjectdown', this.destroyShip, this);

        //create the power-ups for the game
        //there will be a maximum of 4 power-ups
        //set the power-ups to be located at a random position within the game
        this.powerUps = this.physics.add.group();

        var maxObjects = 4;
        for (var i=0; i <= maxObjects; i++) {
            var powerUp = this.physics.add.sprite(16, 16, "power-up");
            this.powerUps.add(powerUp);
            powerUp.setRandomPosition(0, 0, game.config.width, game.config.height);

            //make it a 50/50 chance of the animation being either red or gray
            if (Math.random() > 0.5) {
                powerUp.play("red");
            }
            else {
                powerUp.play("gray");
            }

            //set the velocity of the power-up to control how it travels on the screen
            //because we want the power-ups to collide with the boundaries, set the value to be true
            //because we want the power-ups to bounce off the boundaries, we set a bounce value
            //we want to keep its full velocity as it bounces, so the value will be 1
            powerUp.setVelocity(100, 100);
            powerUp.setCollideWorldBounds(true);
            powerUp.setBounce(1);
        }

        //add the player alongside its animation
        this.player = this.physics.add.sprite(config.width / 2 - 8, config.height - 64, "player");
        this.player.play("thrust");

        //listen for any keyboard events
        this.cursorKeys = this.input.keyboard.createCursorKeys();

        //look for any collisions 
        this.player.setCollideWorldBounds(true);

        //give the player the ability to use the spacebar
        this.spacebar = this.input.keyboard.addKey(Phaser.Input.Keyboard.KeyCodes.SPACE);

        this.projectiles = this.add.group();

        //enable any collisions that take place between objects
        //and groups of objects
        //third parameter uses an anonymous function which is called back
        //as the collision occurs
        this.physics.add.collider(this.projectiles, this.powerUps, function (projectile, powerUp) {
            projectile.destroy(); //destroys the shot as it collides with the object
        });
        //make the player pick up the power-up whenever the player touches it
        this.physics.add.overlap(this.player, this.powerUps, this.pickPowerUp, null, this);

        this.physics.add.overlap(this.player, this.enemies, this.hurtPlayer, null, this);

        this.physics.add.overlap(this.projectiles, this.enemies, this.hitEnemy, null, this);

        //create the graphics for the text
        //set the color of the text
        //and the size and length of the text
        var graphics = this.add.graphics();
        graphics.fillStyle(0x000000, 1);
        graphics.beginPath();
        graphics.moveTo(0, 0);
        graphics.lineTo(config.width, 0);
        graphics.lineTo(config.width, 20);
        graphics.lineTo(0, 20);
        graphics.lineTo(0, 0);
        graphics.closePath();
        graphics.fillPath();

        //set the score at startup - in this case it'll be 0
        this.score = 0;

        //create the score
        this.scoreLabel = this.add.bitmapText(10, 5, "pixelFont", "SCORE ", 16);

        //create the sounds
        this.beamSound = this.sound.add("audio_beam");
        this.explosionSound =  this.sound.add("audio_explosion");
        this.pickupSound = this.sound.add("audio_pickup");

        this.music = this.sound.add("music");

        var musicConfig = {
            mute: false,
            volume: 1,
            rate: 1,
            detune: 0,
            seek: 0,
            loop: false,
            delay: 0
        }
        this.music.play(musicConfig);
    }

    //function to pick up the power-ups
    pickPowerUp(player, powerUp) {
        powerUp.disableBody(true, true); //because the player is picking up the pick-ups, 
        //both parameters are set to true
        this.pickupSound.play(); //play the sound
    }

    //function that causes the player to be hurt
    hurtPlayer(player, enemy) {
        this.resetShipPos(enemy); //reset the ship position
        //prevent the player from being destroyed as it's transparent
        //that way, the player has time to recover before
        //starting the game again
        if (this.player.alpha < 1) {
            return;
        }

        var explosion = new Explosion(this, player.x, player.y); //makes an instance of the explosion class
        player.disableBody(true, true); //this will disable the ship and hide it after it explodes
        //this.resetPlayer(); //call the function

        this.time.addEvent({
            delay: 1000, //delays for 1000 milliseconds, or 1 second
            callback: this.resetPlayer, // the object we want to use
            callbackScope: this,
            loop: false //meaning this will only be 1000 milliseconds
        });
    }

    //function that will destroy our shot when it's struck by an enemy
    hitEnemy(projectile, enemy) {
        var explosion = new Explosion(this, enemy.x, enemy.y); //makes an instance of the explosion class
        projectile.destroy(); //destroys the shot
        this.resetShipPos(enemy); //resets the enemy ship position
        this.score +=15; //after every enemy is hit, add 15 points
        var scoreFormatted = this.zeroPad(this.score, 6);
        this.scoreLabel.text = "SCORE " + scoreFormatted; //update the score
        this.explosionSound.play(); //play the explosion sound
    }

    //function to move the ship
    moveShip(ship, speed) {
        ship.y += speed; //this will move the ship on the y axis
        //if the ship exceeds its vertical position, reset the position of the ship
        if (ship.y > config.height) {
            this.resetShipPos(ship);
        }
    }

    //function to reset the position of the ship
    resetShipPos(ship) {
        ship.y = 0; //sets y position to 0
        var randomX = Phaser.Math.Between(0, config.width); //creates a random value between 0 and the width of the game 
                                                            //which in this case is 256
        ship.x = randomX;
    }

    //function to reset the position of the player
    resetPlayer() {
        var x = config.width / 2 - 8;
        var y = config.height + 64;
        this.player.enableBody(true, x, y, true, true);

        this.player.alpha = 0.5; //this makes the player transparent

        //create a tween
        var tween = this.tweens.add({
            targets: this.player,
            y: config.height - 64,
            ease: 'Power1',
            duration: 1500,
            repeat: 0,
            onComplete: function() {
                this.player.alpha = 1;
            },
            callbackScope: this
        });
    }

    //function to destroy the ship
    destroyShip(pointer, gameObject) {
        gameObject.setTexture("explosion"); //switch texture of the ship to the explosion
        gameObject.play("explode"); //play the animation
    }

    //function to shoot the beam
    shootBeam() {
        var beam = new Beam(this);
        this.beamSound.play(); //play the noise
    }

    //function to create the format of the score
    zeroPad(number, size) {
        var stringNumber = String(number);
        while (stringNumber.length < (size || 2)) {
            stringNumber = "0" + stringNumber;
        }
        return stringNumber;
    }

    //function to update all of the necessary objects
    update() {
        this.moveShip(this.ship1, 1);
        this.moveShip(this.ship2, 2);
        this.moveShip(this.ship3, 3);

        this.background.tilePositionY -= 0.5; //decrease position of the texture of the background
        this.movePlayerManager(); //calls a function to control the player's ship

        //if the user presses the spacebar, something will occur
        //in this case, "Fire" will show up in the console (NOT on screen)
        if (Phaser.Input.Keyboard.JustDown(this.spacebar)) {
            if (this.player.active) {
                this.shootBeam(); //call the function
            }
        }

        //iterate through each element of the projectile group
        //this will run through the update of each beam
        for (var i=0; i < this.projectiles.getChildren().length; i++) {
            var beam = this.projectiles.getChildren()[i];
            beam.update();
        }
    }

    //function to determine how the player's ship will move

    //if the left key is pressed down, adjust the speed
    //else, if the right key is pressed down, adjust the speed
    //have the player move both horizontally and vertically
    movePlayerManager() {
        if (this.cursorKeys.left.isDown) {
            this.player.setVelocityX(-gameSettings.playerSpeed);
        }
        else if (this.cursorKeys.right.isDown) {
            this.player.setVelocityX(gameSettings.playerSpeed);
        }

        if (this.cursorKeys.up.isDown) {
            this.player.setVelocityY(-gameSettings.playerSpeed);
        }
        else if (this.cursorKeys.down.isDown) {
            this.player.setVelocityY(gameSettings.playerSpeed);
        }
    }
}