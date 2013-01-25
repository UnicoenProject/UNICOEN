methods = open('java.g', 'r') { |f| f.readlines.map { |s| s.strip } }

source = methods.map { |m|
%Q{
        public static IUnifiedElement Create#{m[0].upcase + m[1..-1]}(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "#{m}");
            throw new NotImplementedException(); //TODO: implement
        }
}
}.join

open('out.txt', 'w') { |f| f.write source }
