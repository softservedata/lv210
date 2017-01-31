describe('Computer', function () {
    
    beforeEach(function () {
        Computer.currentMemoryGbs = 2;
        Computer.currentSpaceCBs = 1000;
    });
    
    describe('When increases physical memory', function() {
        it('Should have possibility to increase his own physical memory', function () {
            expect( Computer.addMemory(6) ).toEqual(8)
        });

        it('Should show current amount of memory', function () {
            expect(Computer.currentMemoryGbs).toBeDefined();
            expect(Computer.currentMemoryGbs).toEqual(2);
        });
        
        it('Should prohibit to add more than two memory cards', function () {
            expect(Computer.addMemory(6,8)).toEqual(16);
            expect(Computer.addMemory(6,8,4)).toBe(false);
        });
    });
    
    describe('When installing programms', function () {
        it('Should be able install any count programs', function () {
            expect(Computer.install({name: 'GTA4', space: 600, installed: false}, {name: 'Photoshop', space: 400, installed: false})).toBe(true);
        });
        
        it('Should prohibit to install programs, when there are not free space', function () {
            expect(Computer.install({name: 'GTA4', space: 600, installed: false}, {name: 'Photoshop', space: 400, installed: false}, 
                                    {name:'Sublime Text 2', space: 1, installed: false})).toBe(false);
        });
        
        it('Shoud be able formatting hard disk', function () {
            Computer.install({name: 'GTA4', space: 600, installed: false});
            console.log(Computer.currentSpaceCBs);
            Computer.formatDrive();
            console.log(Computer.currentSpaceCBs);
            expect(Computer.currentSpaceCBs).toEqual(1000);
        });
    })
})