using System;

namespace compiler_app
{
    class Token
    {
        private String info, type;
        private int line, ID;

        public Token() { 
        }

        public Token(String info, String type, int line, int ID) {
            this.info = info;
            this.type = type;
            this.line = line;
            this.ID = ID;
        }

        public void setInfo(String info) {
            this.info = info;
        }

        public void setType(String type) {
            this.type = type;
        }

        public void setLine(int line) {
            this.line = line;
        }

        public void setID(int id) {
            this.ID = id;
        }

        public string getType() {
            return this.type;
        }

        public string getInfo() {
            return this.info;
        }

        public int getID() {
            return this.ID;
        }

        public int getLine() {
            return this.line;
        }
    }
}
