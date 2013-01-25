methods = open('grammar.txt', 'r') { |f|
  f.readlines
    .select { |s| s.size > 0 && s[0] != " " && s[0] != "#" && s.include?(":") }
    .map { |s| [s.split(":")[0].strip, s] }
}

source = methods.map { |m, g|
%Q{
        public static IUnifiedElement Create#{m[0].upcase + m[1..-1]}(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "#{m}");
            /*
             * #{g.strip}
             */
            throw new NotImplementedException(); //TODO: implement
        }
}
}.join

open('out.txt', 'w') { |f| f.write source }
