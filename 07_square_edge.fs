// Author @patriciogv - 2015
// http://patriciogonzalezvivo.com

#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

vec3 drawSquare(float left, float right, float up, float down, vec2 st, vec3 color)
{
    
    vec2 bl = step(vec2(left, down),st);       // bottom-left
    vec2 tr = step(vec2(1. - right, 1. - up),1.0-st);   // top-right
    return color * vec3(bl.x * bl.y * tr.x * tr.y);
}

vec3 drawSquareEdge(float left, float right, float up, float down, vec2 st, vec3 color)
{
    float x = step(left-0.01,st.x) - step(left+0.01, st.x)+
        step(right-0.01,st.x) - step(right+0.01, st.x);
    float y = step(down-0.01,st.y) - step(down+0.01, st.y)+
        step(up-0.01,st.y) - step(up+0.01, st.y);
    vec2 bl = step(vec2(left, down),st);       // bottom-left
    vec2 tr = step(vec2(1. - right, 1. - up),1.0-st);   // top-right
    
    return color * vec3(clamp(0.,1.,(x+y))*bl.x * bl.y * tr.x * tr.y);
}

void main(){
    vec2 st = gl_FragCoord.xy/u_resolution.xy;
    vec3 color = vec3(0.0);

    // bottom-left
    
    vec3 beige = vec3(239.,230.,212.)/255.;
    vec3 red = vec3(167.,32.,36.)/255.;
    vec3 blue = vec3(1.,95.,156.) / 255.;
    vec3 yellow = vec3(252.,196.,40.)/255.;


    color += drawSquareEdge(0.200,0.834,0.821,.090, st, beige);



     
    gl_FragColor = vec4(color,1.0);
}
