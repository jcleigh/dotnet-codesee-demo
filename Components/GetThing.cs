namespace dotnet_codesee_demo.Components
{
    public class GetThing
    {
        public class Request { }

        public class Response
        {
            public object? Thing { get; set; }
        }

        public GetThing() { }

        public Response Execute(Request request)
        {
            var thing = new
            {
                Foo = "bar",
                Baz = "qux",
                Quux = "quuz",
                Corge = "grault",
                Garply = "waldo",
                Fred = "plugh",
                Xyzzy = "thud"
            };

            var returnThingRandomly = new Random().Next(0, 1) == 0;

            return new Response
            {
                Thing = returnThingRandomly ? thing : null
            };
        }
    }
}
