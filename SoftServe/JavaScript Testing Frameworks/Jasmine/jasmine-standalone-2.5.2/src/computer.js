window.Computer = {
    currentMemoryGbs : 2,
    currentSpaceCBs : 1000,
    addMemory: function () {
        var memory = this.currentMemoryGbs;
        
        if (arguments.length <= 2) {
            for (var i = 0, len = arguments.length; i < len; i++){    
                memory += arguments[i];   
            }
        }
        else {
            return false;
        }
        
        this.currentMemoryGbs = memory;
        return memory;
    },
    
    install : function () {
        for (var i = 0, len = arguments.length; i < len; i++) {
            if (arguments[i].space <= this.currentSpaceCBs) {
                
                this.currentSpaceCBs -= arguments[i].space;
                arguments[i].installed = true; 
                
            }
        }
        
        for (var i = 0, len = arguments.length; i < len; i++) {
            if(arguments[i].installed === false) {
                return false;
            }
        }
        
        return true;
    },
    
    formatDrive : function () {
    this.currentSpaceCBs = 1000;
    }, 
};