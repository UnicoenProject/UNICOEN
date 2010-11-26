using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CStatement
	{
		private XElement _node;		// statement
		public string Type;

		public IEnumerable<CExpression> Expressions{
			get{
				return _node.Descendants("expression")
					.Select(e => new CExpression(e));
			}
		}

		// constructor
		public CStatement(XElement node, string type = "")
		{
			_node = node;
			Type = type;
		}
		public CStatement()
		{
		}
	}
}
/*
            <selection_statement>
              <TOKEN startline="2" startpos="1">if</TOKEN>
              <TOKEN startline="2" startpos="3">(</TOKEN>
              <expression>
                <assignment_expression>
                  <conditional_expression>
                    <logical_or_expression>
                      <logical_and_expression>
                        <inclusive_or_expression>
                          <exclusive_or_expression>
                            <and_expression>
                              <equality_expression>
                                <relational_expression>
                                  <shift_expression>
                                    <additive_expression>
                                      <multiplicative_expression>
                                        <cast_expression>
                                          <unary_expression>
                                            <postfix_expression>
                                              <primary_expression>
                                                <TOKEN startline="2" startpos="4">n</TOKEN>
                                              </primary_expression>
                                            </postfix_expression>
                                          </unary_expression>
                                        </cast_expression>
                                      </multiplicative_expression>
                                    </additive_expression>
                                  </shift_expression>
                                  <TOKEN startline="2" startpos="6">&lt;</TOKEN>
                                  <shift_expression>
                                    <additive_expression>
                                      <multiplicative_expression>
                                        <cast_expression>
                                          <unary_expression>
                                            <postfix_expression>
                                              <primary_expression>
                                                <constant>
                                                  <TOKEN startline="2" startpos="8">2</TOKEN>
                                                </constant>
                                              </primary_expression>
                                            </postfix_expression>
                                          </unary_expression>
                                        </cast_expression>
                                      </multiplicative_expression>
                                    </additive_expression>
                                  </shift_expression>
                                </relational_expression>
                              </equality_expression>
                            </and_expression>
                          </exclusive_or_expression>
                        </inclusive_or_expression>
                      </logical_and_expression>
                    </logical_or_expression>
                  </conditional_expression>
                </assignment_expression>
              </expression>
*/