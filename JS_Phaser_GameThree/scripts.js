(function(){

    //phaser code goes here
    //configure the size of the canvas
    var config = {
        type: Phaser.AUTO,
        width: 800,
        height: 600,
        physics: {
            default: 'arcade',
            arcade: {
                gravity: { y: 300},
                debug: false
            }
        },
        scene: {
            preload: preload,
            create: create,
            update: update
        }
    };
    
    var game = new Phaser.Game(config);
    
    //function to load all of the assets we need
    function preload ()
    {
        this.load.image('sky', 'assets/sky.png');
        this.load.image('ground', 'assets/platform.png');
        this.load.image('star', 'assets/star.png');
        this.load.image('bomb', 'assets/bomb.png');
        this.load.spritesheet('dude', 
            'assets/dude.png',
            { frameWidth: 32, frameHeight: 48 }
        );
    }

    //variable to create some platforms
    var platforms;

    //variable to declare the score, and the text
    var score = 0;
    var scoreText;

    
    //function to create the objects and all of the necessary collision detections
    function create ()
    {
        //creates the sky and the star
        //NOTE: place sky before star, or else the star will disappear
        this.add.image(400, 300, 'sky');

        //create all of the necessary platforms
        //there will be 4 in total
        platforms = this.physics.add.staticGroup(); //creates a new physics group, and is assigned to the platforms variable
        platforms.create(400, 568, 'ground').setScale(2).refreshBody();
        platforms.create(600, 400, 'ground');
        platforms.create(50, 250, 'ground');
        platforms.create(750, 220, 'ground');

        //create the player and all of the ways it can move
        //in this case, it will move left, right and turn in both directions
        player = this.physics.add.sprite(100, 450, 'dude');
        player.setBounce(0.2);
        player.setCollideWorldBounds(true);
        
        this.anims.create({
            key: 'left',
            frames: this.anims.generateFrameNumbers('dude', { start: 0, end: 3}),
            frameRate: 10,
            repeat: -1
        });

        this.anims.create({
            key: 'turn',
            frames: [ { key: 'dude', frame: 4 } ],
            frameRate: 20
        });
        
        this.anims.create({
            key: 'right',
            frames: this.anims.generateFrameNumbers('dude', { start: 5, end: 8 }),
            frameRate: 10,
            repeat: -1
        });

        this.physics.add.collider(player, platforms); //this will test any collisions between the player and the platform
        //this.add.image(400, 300, 'star');

        //add all of the necessary stars to the screen
        stars = this.physics.add.group({
            key: 'star',
            repeat: 11,
            setXY: { x: 12, y: 0, stepX: 70 }
        });
        
        stars.children.iterate(function (child) {
        
            child.setBounceY(Phaser.Math.FloatBetween(0.4, 0.8));
        
        });

        //this will test any collision with the stars on the platform
        this.physics.add.collider(stars, platforms);

        //this will test to see if the player is overlapping with the star or not
        this.physics.add.overlap(player, stars, collectStar, null, this);

        //this will create the score text on the screen - with the starting number, the font size, and the color
        scoreText = this.add.text(16, 16, 'score: 0', { fontSize: '32px', fill: '#000' });

        bombs = this.physics.add.group();

        this.physics.add.collider(bombs, platforms);
    
        this.physics.add.collider(player, bombs, hitBomb, null, this);
     
    }
    
    //function to update as necessary
    //create if-elif-else block to check whenever the left and right keys have been pressed
    function update ()
    {
        //variable that uses the built-in keyboard manager to figure out which keys will be used
        cursors = this.input.keyboard.createCursorKeys();

        if (cursors.left.isDown) {
            player.setVelocityX(-160);
            player.anims.play('left', true);
        }
        else if (cursors.right.isDown) {
            player.setVelocityX(160);
            player.anims.play('right', true);
        }
        else {
            player.setVelocityX(0);
            player.anims.play('turn');
        }
        if (cursors.up.isDown && player.body.touching.down) {
            player.setVelocityY(-330);
        }
    }
    //function to detect if there's an overlap between the player and the star
    //this will remove the star(s) from the screen
    function collectStar (player, star){

        star.disableBody(true, true);

        //this updates the score by 10 every time a star is captured
        score += 10;
        scoreText.setText('Score: ' + score);

        if (stars.countActive(true) === 0) {
        stars.children.iterate(function (child) {

            child.enableBody(true, child.x, 0, true, true);

        });

            var x = (player.x < 400) ? Phaser.Math.Between(400, 800) : Phaser.Math.Between(0, 400);
            var bomb = bombs.create(x, 16, 'bomb');
            bomb.setBounce(1);
            bomb.setCollideWorldBounds(true);
            bomb.setVelocity(Phaser.Math.Between(-200, 200), 20);
            
        }
   }
    //function to determine if the player hits the bomb
    //if they do, the game ends
    function hitBomb(player, bomb) {
        this.physics.pause();

        player.setTint(0xff0000);

        player.anims.play('turn');

        gameOver = true;
    }
})();