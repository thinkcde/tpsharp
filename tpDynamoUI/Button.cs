using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamo.Graph.Nodes;
using Dynamo.Nodes;
using Dynamo.Wpf;
using System.Windows;
using Dynamo.Controls;
using System.Threading;
using ProtoCore.AST.AssociativeAST;
using Dynamo.Graph;
using System.Xml;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace tpDynamoUI
{
    [IsDesignScriptCompatible]
    [NodeName("Trigger Button")]
    [NodeCategory("tpDynamo")]
    [NodeDescription("Trigger Button for Sending")]
    [OutPortNames("Boolean")]
    [OutPortTypes("bool")]
    [OutPortDescriptions("Boolean Value, shortly true on click")]
    public class TriggerButton : NodeModel
    {
        private bool _value = false;

        public bool Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged("Value");
                OnNodeModified(false);
            }
        }

        [JsonConstructor]
        public TriggerButton(IEnumerable<PortModel> inPorts, IEnumerable<PortModel> outPorts) : base(inPorts, outPorts) { }

        public TriggerButton()
        {
            RegisterAllPorts();
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            var data = AstFactory.BuildBooleanNode(Value);
            var assignment = AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), data);
            return new[] { assignment };
        }
    }

    public class ButtonView : INodeViewCustomization<TriggerButton>
    {
        public void CustomizeView(TriggerButton trigger, NodeView nodeView)
        {
            var button = new Button();
            button.HorizontalAlignment = HorizontalAlignment.Stretch;
            button.VerticalAlignment = VerticalAlignment.Stretch;
            button.Content = "Click to Upload";
            button.Click += Button_Click;
            nodeView.inputGrid.Children.Add(button);
            button.DataContext = trigger;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            TriggerButton t = button.DataContext as TriggerButton;

            t.Value = true;
            System.Threading.Thread.Sleep(80);
            t.Value = false;
        }

        public void Dispose()
        {
        }

    }
}


