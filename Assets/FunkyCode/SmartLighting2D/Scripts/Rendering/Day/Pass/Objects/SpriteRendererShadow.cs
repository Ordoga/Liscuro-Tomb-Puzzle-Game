using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rendering.Day {

    public class SpriteRendererShadow {
        static VirtualSpriteRenderer virtualSpriteRenderer = new VirtualSpriteRenderer();

        static public void Draw(DayLightCollider2D id, Vector2 offset) {
            if (id.mainShape.shadowType != DayLightCollider2D.ShadowType.SpriteOffset) {
                return;
            }

            if (id.InAnyCamera() == false) {
                return;
            }

            Material material = Lighting2D.materials.GetSpriteShadow();
            material.color = Color.black;

            foreach(DayLightColliderShape shape in id.shapes) {
                
                SpriteRenderer spriteRenderer = shape.spriteShape.GetSpriteRenderer();
                if (spriteRenderer == null) {
                    continue;
                }
                
                virtualSpriteRenderer.sprite = spriteRenderer.sprite;
                virtualSpriteRenderer.flipX = spriteRenderer.flipX;
                virtualSpriteRenderer.flipY = spriteRenderer.flipY;

                if (virtualSpriteRenderer.sprite == null) {
                    continue;
                }
                                    
                float x = id.transform.position.x + offset.x;
                float y = id.transform.position.y + offset.y;

                float rot = -Lighting2D.DayLightingSettings.direction * Mathf.Deg2Rad;

                float sunHeight = Lighting2D.DayLightingSettings.height;

                x += Mathf.Cos(rot) * id.mainShape.height * sunHeight;
                y += Mathf.Sin(rot) * id.mainShape.height * sunHeight;

                material.mainTexture = virtualSpriteRenderer.sprite.texture;

                Vector2 scale = new Vector2(id.transform.lossyScale.x, id.transform.lossyScale.y);

                Universal.Sprite.FullRect.Simple.Draw(id.spriteMeshObject, material, virtualSpriteRenderer, new Vector2(x, y), scale, id.transform.rotation.eulerAngles.z);
            }

            material.color = Color.white;
        }

          static public void DrawProjection(DayLightCollider2D id, Vector2 offset) {
            if (id.mainShape.shadowType != DayLightCollider2D.ShadowType.SpriteProjection) {
                return;
            }

            if (id.InAnyCamera() == false) {
                return;
            }

            Material material = Lighting2D.materials.GetSpriteShadow();
            material.color = Color.black;

            foreach(DayLightColliderShape shape in id.shapes) {
                SpriteRenderer spriteRenderer = shape.spriteShape.GetSpriteRenderer();
                if (spriteRenderer == null) {
                    continue;
                }
                
                virtualSpriteRenderer.sprite = spriteRenderer.sprite;
                virtualSpriteRenderer.flipX = spriteRenderer.flipX;
                virtualSpriteRenderer.flipY = spriteRenderer.flipY;

                Sprite sprite = virtualSpriteRenderer.sprite;

                if (virtualSpriteRenderer.sprite == null) {
                    continue;
                }

            
                float sunHeight = Lighting2D.DayLightingSettings.height;
                
                float x = id.transform.position.x + offset.x;
                float y = id.transform.position.y + offset.y;
                Vector2 pos = new Vector2(x, y);

  
                Vector2 scale = new Vector2(id.transform.lossyScale.x, id.transform.lossyScale.y);

                SpriteTransform spriteTransform = new SpriteTransform(virtualSpriteRenderer, pos, scale, id.transform.rotation.eulerAngles.z);

                Rect uv = spriteTransform.uv;
                Vector2 size = spriteTransform.scale;

                float rectAngle = Mathf.Atan2(size.y, size.x);
                float dist = Mathf.Sqrt(size.x * size.x + size.y * size.y);

                float pivotUV = (float)sprite.pivot.y / sprite.texture.height;
                pivotUV = uv.y + pivotUV;

                List<Polygon2> polygons = shape.GetPolygonsWorld();

                if (polygons.Count < 1) {
                    continue;
                }

                Polygon2 poly = polygons[0];

                float rot = Lighting2D.DayLightingSettings.direction * Mathf.Deg2Rad;


                Pair2 pair = Polygon2Helper.GetAxis(poly, rot);

                Vector2 v1 = pair.A + offset;
                Vector2 v2 = pair.A + offset;
                Vector2 v3 = pair.B + offset;
                Vector2 v4 = pair.B + offset;

                v2 = v2.Push(-rot, id.shadowDistance);
                v3 = v3.Push(-rot, id.shadowDistance);

                material.mainTexture = virtualSpriteRenderer.sprite.texture;
        
                material.SetPass (0); 
        
                GL.Begin (GL.QUADS);

                GL.Color(GLExtended.color);

                GL.TexCoord3 (uv.x, pivotUV, 0);
                GL.Vertex3 (v1.x, v1.y, 0);

                GL.TexCoord3 (uv.x, uv.height, 0);
                GL.Vertex3 (v2.x, v2.y, 0);

                GL.TexCoord3 (uv.width, uv.height, 0);
                GL.Vertex3 (v3.x, v3.y, 0);

                GL.TexCoord3 (uv.width, pivotUV, 0);
                GL.Vertex3 (v4.x, v4.y, 0);

                GL.End ();
            }

            material.color = Color.white;
        }
    }
}